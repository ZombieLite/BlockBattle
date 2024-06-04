using UnityEngine;
using UnityEngine.UI;

public class AbilitySpeed : MonoBehaviour
{
    [SerializeField] GameObject buttonPlus;
    [SerializeField] GameObject txtSpeed;
    private static GameObject _txtSpeed;
    private static GameObject _buttonPlus;

    private static float _speed = 0.0f;

    private void Awake()
    {
        _txtSpeed = txtSpeed;
        _buttonPlus = buttonPlus;
    }

    private void Start()
    {
        UpdateHud();
    }

    public static void SetSpeed(float num)
    {
        _speed = num;
        UpdateHud();
    }

    public static float GetSpeed()
    {
        return _speed;
    }

    public static void AddSpeed()
    {
        _speed += 0.01f;
        UpdateHud();
    }

    private static void UpdateHud()
    {
        _txtSpeed.GetComponent<Text>().text = "+"+Mathf.Round(_speed*100).ToString()+"%";

        if(_speed >= 1.79)
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
