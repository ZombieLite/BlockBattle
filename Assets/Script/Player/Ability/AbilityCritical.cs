using UnityEngine;
using UnityEngine.UI;

public class AbilityCritical : MonoBehaviour
{
    [SerializeField] GameObject buttonPlus;
    [SerializeField] GameObject txt;
    private static GameObject _txt;
    private static GameObject _buttonPlus;

    private static float _critical = 5.0f;

    private void Awake()
    {
        _txt = txt;
        _buttonPlus = buttonPlus;
    }

    private void Start()
    {
        UpdateHud();
    }

    public static void SetCritical(float num)
    {
        _critical = num;
        UpdateHud();
    }

    public static float GetCritical()
    {
        return _critical;
    }

    public static void AddCritical()
    {
        _critical += 0.1f;
        UpdateHud();
    }

    private static void UpdateHud()
    {
        string reulst = string.Format("{0:f1}", _critical);
        _txt.GetComponent<Text>().text = ""+reulst+"%";

        if (_critical >= 99.99)
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
