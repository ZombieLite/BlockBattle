using UnityEngine;
using YG;

public class AdminMenu : MonoBehaviour
{
    public void ResetSave()
    {
        YandexGame.ResetSaveProgress();
        YandexGame.SaveProgress();
    }
}
