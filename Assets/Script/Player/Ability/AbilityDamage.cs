using UnityEngine;
using UnityEngine.UI;

public class AbilityDamage : MonoBehaviour
{
    [SerializeField] GameObject buttonPlus;
    [SerializeField] GameObject txt;
    private static GameObject _txt;

    private static int _damage = 0;

    private void Awake()
    {
        _txt = txt;
    }

    private void Start()
    {
        UpdateHud();
    }

    public static void SetDamage(int num)
    {
        _damage = num;
        UpdateHud();
    }

    public static int GetDamage()
    {
        return _damage;
    }

    public static void AddDamage()
    {
        _damage++;
        UpdateHud();
    }

    private static void UpdateHud()
    {
        _txt.GetComponent<Text>().text = "+"+_damage.ToString();
    }
}
