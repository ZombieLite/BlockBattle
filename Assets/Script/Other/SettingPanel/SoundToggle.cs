using UnityEngine;
using UnityEngine.UI;
using YG;

public class SoundToggle : MonoBehaviour
{
    [SerializeField] GameObject toggle;

    void Start()
    {
        if(YandexGame.savesData.sound)
        {
            toggle.GetComponent<Toggle>().isOn = true;
            AudioListener.volume = 1;
        } else
        {
            toggle.GetComponent<Toggle>().isOn = false;
            AudioListener.volume = 1;
        }
    }

    public void Toggle()
    {
        if(toggle.GetComponent<Toggle>().isOn)
        {
            AudioListener.volume = 1;
            YandexGame.savesData.sound = true;
        } else
        {
            AudioListener.volume = 0;
            YandexGame.savesData.sound = false;
        }
        Core.SaveProgress();
    }
}
