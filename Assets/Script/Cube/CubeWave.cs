using UnityEngine;
using UnityEngine.UI;
using YG;

public class CubeWave : MonoBehaviour
{
    [SerializeField] GameObject progressBar;
    [SerializeField] GameObject progressText;

    private static GameObject _progressBar;
    private static GameObject _progressText;
    private static GameObject _this;
    private void Start()
    {
        _progressBar = progressBar;
        _progressText = progressText;
        _this = gameObject;
    }

    private static int wave = 1, progress = 0, progressNeed = 10;

    public static void SetWave(int _wave)
    {
        wave = _wave;
        progress = 0;
        UpdateHud();
    }

    public static int GetWave()
    {
        return wave;
    }

    public static void AddProgress(int _progress)
    {
        if(progress + _progress > progressNeed)
        {
            progressNeed++;
            SetWave(wave + 1);
            _this.GetComponent<AudioSource>().Play();
            Core.SaveProgress();

            if (YandexGame.auth == true)
                YandexGame.NewLeaderboardScores("leader", CubeWave.GetWave());

            return;
        }
        progress += _progress;
        UpdateHud();
    }

    public static void UpdateHud()
    {
        _progressBar.GetComponent<Image>().fillAmount = (float)progress / (float)progressNeed;
        _progressText.GetComponent<Text>().text = "Волна " + wave;
    }
}
