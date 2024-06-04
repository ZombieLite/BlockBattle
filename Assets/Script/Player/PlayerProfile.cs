using UnityEngine.UI;
using UnityEngine;
using YG;

public class PlayerProfile : MonoBehaviour
{
    [SerializeField] ImageLoadYG imageLoad;
    [SerializeField] GameObject playerName;
    [SerializeField] GameObject playerImage;
    [SerializeField] Sprite playerNoAvatar;
    private void OnEnable()
    {
        YandexGame.GetDataEvent += YandexDataCheck;
    }
    private void OnDisable()
    {
        YandexGame.GetDataEvent -= YandexDataCheck;
    }

    private void YandexDataCheck()
    {
        if (!YandexGame.auth)
            return;

        playerName.GetComponent<Text>().text = "Привет, " + YandexGame.playerName + "!";
        if (imageLoad != null)
        {
            imageLoad.Load(YandexGame.playerPhoto);
        }
    }
}
