using UnityEngine.Events;
using UnityEngine;
using YG;

public class Core : MonoBehaviour
{
    [SerializeField] GameObject deathPanel;
    [SerializeField] Joystick joystick;

    public static UnityEvent GameOver = new UnityEvent();

    public void OnEnable()
    {
        GameOver.AddListener(gameOverEvent);
        YandexGame.GetDataEvent += GetLoad;
    }
    public void OnDisable()
    {
        GameOver.RemoveListener(gameOverEvent);
        YandexGame.GetDataEvent -= GetLoad;
    }

    private void gameOverEvent()
    {
        deathPanel.SetActive(true);
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetLoad();
        }
    }

    public void GetLoad()
    {
        if (YandexGame.auth == false)
            return;

        CubeWave.SetWave(YandexGame.savesData.wave);
        LevelPlayer.instance.SetLevel(YandexGame.savesData.level);
        LevelPlayer.instance.SetExp(YandexGame.savesData.exp);
        Ability.SetAbility(YandexGame.savesData.ability);
        AbilityExp.SetExp(YandexGame.savesData.bonusexp);
        AbilitySpeed.SetSpeed(YandexGame.savesData.bonusspeed);
        AbilityDamage.SetDamage(YandexGame.savesData.bonusdamage);
        AbilityKnockback.SetKnockback(YandexGame.savesData.bonusknockback);
        AbilityCritical.SetCritical(YandexGame.savesData.bonuscritical);
        joystick.crosshairSpeed = YandexGame.savesData.sensetive;

        AudioListener.volume = YandexGame.savesData.sound ? 1 : 0;
    }

    public static void SaveProgress()
    {
        if (YandexGame.auth == false)
            return; 

        YandexGame.savesData.wave = CubeWave.GetWave();
        YandexGame.savesData.level = LevelPlayer.instance.GetLevel();
        YandexGame.savesData.exp = LevelPlayer.instance.GetExp();
        YandexGame.savesData.ability = Ability.GetAbility();
        YandexGame.savesData.bonusexp = AbilityExp.GetExp();
        YandexGame.savesData.bonusspeed = AbilitySpeed.GetSpeed();
        YandexGame.savesData.bonusdamage = AbilityDamage.GetDamage();
        YandexGame.savesData.bonusknockback = AbilityKnockback.GetKnockback();
        YandexGame.savesData.bonuscritical = AbilityCritical.GetCritical();

        YandexGame.SaveProgress();
        YandexGame.NewLeaderboardScores("leader", CubeWave.GetWave());
    }

    public void EventSoundAbilityUpgrade()
    {
        GetComponent<AudioSource>().Play();
    }
}
