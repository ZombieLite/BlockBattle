using UnityEngine;
using UnityEngine.UI;

public class AbilityKnockback : MonoBehaviour
{
    [SerializeField] GameObject buttonPlus;
    [SerializeField] GameObject txt;
    private static GameObject _txt;
    private static GameObject _buttonPlus;

    private static float _knockback = 0.0f;

    private void Awake()
    {
        _txt = txt;
        _buttonPlus = buttonPlus;
    }

    private void Start()
    {
        UpdateHud();
    }

    public static void SetKnockback(float num)
    {
        _knockback = num;
        UpdateHud();
    }

    public static float GetKnockback()
    {
        return _knockback;
    }

    public static void AddKnockback()
    {
        _knockback += 0.01f;
        UpdateHud();
    }

    private static void UpdateHud()
    {
        _txt.GetComponent<Text>().text = "+"+Mathf.Round(_knockback * 100).ToString()+"%";

        if(_knockback >= 0.99)
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
