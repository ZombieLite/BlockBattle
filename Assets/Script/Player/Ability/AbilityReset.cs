using UnityEngine;
using UnityEngine.UI;
using YG;

public class AbilityReset : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;
    [SerializeField] GameObject choosePanel;

    private void OnEnable() => YandexGame.CloseVideoEvent += Rewarded;
    private void OnDisable() => YandexGame.CloseVideoEvent -= Rewarded;

    int ability = 0;
    int state = 0;

    public void ResetExp()
    {
        if (infoPanel.activeSelf == true)
        {
            infoPanel.SetActive(false);
        }

        int _ability = 0;
        float _exp = AbilityExp.GetExp();

        while (_exp > 1.1) {
            _exp -= 0.1f;
            _ability++;
        }

        if(_ability <= 0)
        {
            infoPanel.SetActive(true);
            return;
        }

        ability = _ability;
        state = 1;

        string szText = "Вы желаете сбросить очки навыков для бонусного опыта. Вы получите " + ability + " очков навыка. Продолжить?";

        choosePanel.SetActive(true);
        choosePanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = szText;
    }

    public void ResetSpeed()
    {
        if (infoPanel.activeSelf == true)
        {
            infoPanel.SetActive(false);
        }

        int _ability = 0;
        float _speed = AbilitySpeed.GetSpeed();

        while (_speed > 0)
        {
            _speed -= 0.01f;
            _ability++;
        }

        if (_ability <= 0)
        {
            infoPanel.SetActive(true);
            return;
        }

        ability = _ability;
        state = 2;

        string szText = "Вы желаете сбросить очки навыков для бонуса к скорости. Вы получите " + ability + " очков навыка. Продолжить?";

        choosePanel.SetActive(true);
        choosePanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = szText;
    }

    public void ResetDamage()
    {
        if (infoPanel.activeSelf == true)
        {
            infoPanel.SetActive(false);
        }

        int _ability = 0;
        float _damage = AbilityDamage.GetDamage();

        while (_damage > 0)
        {
            _damage --;
            _ability++;
        }

        if (_ability <= 0)
        {
            infoPanel.SetActive(true);
            return;
        }

        ability = _ability;
        state = 3;

        string szText = "Вы желаете сбросить очки навыков для бонуса к урону. Вы получите " + ability + " очков навыка. Продолжить?";

        choosePanel.SetActive(true);
        choosePanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = szText;
    }

    public void ResetKnockback()
    {
        if (infoPanel.activeSelf == true)
        {
            infoPanel.SetActive(false);
        }

        int _ability = 0;
        float _knockback = AbilityKnockback.GetKnockback();

        while (_knockback > 0)
        {
            _knockback -= 0.01f;
            _ability++;
        }

        if (_ability <= 0)
        {
            infoPanel.SetActive(true);
            return;
        }

        ability = _ability;
        state = 4;

        string szText = "Вы желаете сбросить очки навыков для бонуса к отдаче. Вы получите " + ability + " очков навыка. Продолжить?";

        choosePanel.SetActive(true);
        choosePanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = szText;
    }

    public void ResetCritical()
    {
        if (infoPanel.activeSelf == true)
        {
            infoPanel.SetActive(false);
        }

        int _ability = 0;
        float _critical = AbilityCritical.GetCritical();

        while (_critical > 5.0)
        {
            _critical -= 0.1f;
            _ability++;
        }

        if (_ability <= 0)
        {
            infoPanel.SetActive(true);
            return;
        }

        ability = _ability;
        state = 5;

        string szText = "Вы желаете сбросить очки навыков для бонуса к двойному урону. Вы получите " + ability + " очков навыка. Продолжить?";

        choosePanel.SetActive(true);
        choosePanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = szText;
    }

    public void AdsAccept()
    {
        YandexGame.RewVideoShow(state + 2);
    }

    private void ResetDecline()
    {
        choosePanel.SetActive(false);
        ability = 0;
        state = 0;
    }

    private void Rewarded(int id)
    {
        id -= 2;

        switch(id)
        {
            case 1:
                AbilityExp.SetExp(1.0f);
                break;
            case 2:
                AbilitySpeed.SetSpeed(0.0f);
                break;
            case 3:
                AbilityDamage.SetDamage(0);
                break;
            case 4:
                AbilityKnockback.SetKnockback(0.0f);
                break;
            case 5:
                AbilityCritical.SetCritical(5.0f);
                break;
        }
        Ability.SetAbility(Ability.GetAbility() + ability);
        ResetDecline();
        Core.SaveProgress();
    }
}
