using UnityEngine;
using UnityEngine.UI;
using YG;

public class buymenu : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;
    [SerializeField] GameObject warningPanel;

    private void OnEnable() 
    {
        YandexGame.CloseVideoEvent += Rewarded;
        YandexGame.PurchaseSuccessEvent += PurchaseSuccess;
        YandexGame.PurchaseFailedEvent += PurchaseFailed;
    }

    private void OnDisable()
    {
        YandexGame.CloseVideoEvent -= Rewarded;
        YandexGame.PurchaseSuccessEvent -= PurchaseSuccess;
        YandexGame.PurchaseFailedEvent -= PurchaseFailed;
    }

    public void AdsFreeAbility()
    {
        YandexGame.RewVideoShow(10);
    }

    public void BuyAbilityOnYan50()
    {
        YandexGame.BuyPayments("5123127");
    }

    public void BuyAbilityOnYan100()
    {
        YandexGame.BuyPayments("63657234");
    }

    public void PurchaseSuccess(string id)
    {
        if(id == "5123127")
        {
            SetAbility(60);
        }

        if(id == "63657234")
        {
            SetAbility(130);
        }
    }

    public void PurchaseFailed(string id)
    {
        if (id == "5123127" || id == "63657234")
        {
            warningPanel.SetActive(false);
            warningPanel.SetActive(true);
        }
    }

    private void Rewarded(int id)
    {
        if (id == 10)
        {
            SetAbility(1);
        }
    }

    private void SetAbility(int num)
    {
        infoPanel.SetActive(false);
        infoPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Вы получили " + num + " очко(ов) навыка!";
        infoPanel.SetActive(true);


        Ability.SetAbility(Ability.GetAbility() + num);
        Core.SaveProgress();
    }
}
