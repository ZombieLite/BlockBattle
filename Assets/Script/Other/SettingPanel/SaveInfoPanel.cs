using UnityEngine;
using UnityEngine.UI;
using YG;

public class SaveInfoPanel : MonoBehaviour
{
    [SerializeField] GameObject panelSaveCompleted;
    [SerializeField] GameObject panelSaveFailed;

    float bufferTime;

    public void SaveToggle()
    {
        if (YandexGame.auth == false)
        {
            panelSaveFailed.SetActive(false);
            panelSaveFailed.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Вы не авторизированы!";
            panelSaveFailed.SetActive(true);
            return;
        }

        if (bufferTime <= Time.time && Time.timeScale > 0)
        {
            bufferTime = Time.time + 10.0f;


            panelSaveFailed.SetActive(false);
            panelSaveCompleted.SetActive(false);

            panelSaveCompleted.SetActive(true);

            Core.SaveProgress();
        } else
        {
            panelSaveCompleted.SetActive(false);
            panelSaveFailed.SetActive(false);

            if(Time.timeScale > 0)
                panelSaveFailed.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Сохранение через " + Mathf.RoundToInt(bufferTime - Time.time) + " секунд.";
            else
                panelSaveFailed.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Только во время игры!";

            panelSaveFailed.SetActive(true);
        }
    }
}
