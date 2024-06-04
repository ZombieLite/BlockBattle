using UnityEngine;
using UnityEngine.UI;

public class AbilityExp : MonoBehaviour
{
    [SerializeField] GameObject buttonPlus;
    [SerializeField] GameObject txtExp;
    private static GameObject _txtExp;
    private static GameObject _buttonPlus;

    private static float _exp = 1.0f;

    private void Awake()
    {
        _txtExp = txtExp;
        _buttonPlus = buttonPlus;
    }

    private void Start()
    {
        UpdateHud();
    }

    public static void SetExp(float num)
    {
        _exp = num;
        UpdateHud();
    }

    public static float GetExp()
    {
        return _exp;
    }

    public static void AddExp()
    {
        _exp += 0.1f;
        UpdateHud();
    }

    private static void UpdateHud()
    {
        _txtExp.GetComponent<Text>().text = "+"+Mathf.Round(((_exp - 1.0f) * 10f) * 10).ToString()+"%";

        if(_exp >= 11)
        {
            _buttonPlus.GetComponent<ReplacePlus>().ReplaceImageInMax();
            _buttonPlus.GetComponent<Button>().interactable = false;
        } else
        {
            _buttonPlus.GetComponent<ReplacePlus>().ReplaceImageInPlus();
            _buttonPlus.GetComponent<Button>().interactable = true;
        }
    }
}
