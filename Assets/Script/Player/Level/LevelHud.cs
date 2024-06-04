using UnityEngine;
using UnityEngine.UI;

public class LevelHud : MonoBehaviour
{
    [SerializeField] GameObject levelBarText;
    [SerializeField] GameObject levelBarPanel;
    [SerializeField] GameObject levelStarsText;

    private void Awake()
    {
        LevelPlayer.LevelUpdate.AddListener(LevelUpdateHud);
    }

    private void Start()
    {
        LevelUpdateHud();
    }

    private void LevelUpdateHud()
    {
        float _procent = (float)LevelPlayer.instance.GetExp() / (float)LevelPlayer.instance.GetMaxExp();

        levelBarText.GetComponent<Text>().text = "" + LevelPlayer.instance.GetExp() + "\\" + LevelPlayer.instance.GetMaxExp();
        levelStarsText.GetComponent<Text>().text = "" + LevelPlayer.instance.GetLevel();
        levelBarPanel.GetComponent<Image>().fillAmount = _procent;
    }

    private void OnDisable()
    {
        LevelPlayer.LevelUpdate.RemoveListener(LevelUpdateHud);
    }
}
