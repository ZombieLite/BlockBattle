using UnityEngine;
using UnityEngine.UI;
using YG;

public class SensetiveCrosshair : MonoBehaviour
{
    [SerializeField] Slider slider;

    private void Start()
    {
        if (YandexGame.EnvironmentData.isDesktop)
            gameObject.SetActive(false);

        slider.value = YandexGame.savesData.sensetive;
    }

    private void OnDisable()
    {
        if (YandexGame.EnvironmentData.isDesktop)
            return;

        YandexGame.savesData.sensetive = slider.value;
        YandexGame.SaveProgress();
    }
}
