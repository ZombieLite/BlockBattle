using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    [SerializeField] GameObject plusExp;
    [SerializeField] GameObject plusSpeed;
    [SerializeField] GameObject plusDamage;
    [SerializeField] GameObject plusKnock;
    [SerializeField] GameObject plusCrit;

    [SerializeField] GameObject txtAbility;
    private static GameObject _txtAbility;

    private static int _ability = 0;

    private void Awake()
    {
        _txtAbility = txtAbility;
    }

    static GameObject _plusExp, _plusSpeed, _plusDamage, _plusKnock, _plusCrit;

    private void Start()
    {
        _plusExp = plusExp;
        _plusSpeed = plusSpeed;
        _plusDamage = plusDamage;
        _plusKnock = plusKnock;
        _plusCrit = plusCrit;

        UpdateHud();
    }

    public static void AddAbility()
    {
        _ability++;
        UpdateHud();
    }

    public static void ReduceAbility()
    {
        _ability--;
        UpdateHud();
    }

    public static void SetAbility(int num)
    {
        _ability = num;
        UpdateHud();
    }

    public static int GetAbility()
    {
        return _ability;
    }

    private static void UpdateHud()
    {
        _txtAbility.GetComponent<Text>().text = _ability.ToString();

        if(_ability <= 0)
        {
            /*
            foreach(GameObject obj in GameObject.FindGameObjectsWithTag("plus"))
            {
                obj.SetActive(false);
            }
            */
            PlusManager(false);
        } else
        {
            /*
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("plus"))
            {
                obj.SetActive(true);
            }
            */
            PlusManager(true);
        }
    }

    private static void PlusManager(bool active)
    {
        _plusExp.SetActive(active);
        _plusSpeed.SetActive(active);
        _plusDamage.SetActive(active);
        _plusKnock.SetActive(active);
        _plusCrit.SetActive(active);
    }
}
