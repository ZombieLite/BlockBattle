using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YG;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] Slider slider;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject crosshair;

    [SerializeField] GameObject stick;
    [SerializeField] GameObject frame;
    [SerializeField] float radius;
    public float crosshairSpeed;
    [Header("Ограничение движения")]
    [SerializeField] float offsets;
    [SerializeField] float yMax;
    [SerializeField] float yMin;
    [SerializeField] float xMax;
    [SerializeField] float xMin;

    private void OnEnable()
    {
        YandexGame.GetDataEvent += GetData;
        slider.onValueChanged.AddListener(ChangeSensetive);
    }
    private void OnDisable()
    {
        YandexGame.GetDataEvent -= GetData;
        slider.onValueChanged.RemoveListener(ChangeSensetive);
    }

    private void ChangeSensetive(float amout)
    {
        crosshairSpeed = amout;
    }

    private void GetData()
    {

        if (YandexGame.EnvironmentData.isDesktop)
            gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        Vector2 _vector = stick.transform.position - frame.transform.position ;
        Vector2 vecNorm = _vector.normalized * offsets;

        /*
        if (crosshair.transform.position.y + vecNorm.y >= yMax || crosshair.transform.position.y + vecNorm.y <= yMin || crosshair.transform.position.x + vecNorm.x <= xMin || crosshair.transform.position.x + vecNorm.x >= xMax)
        {
            return;
        }
        */

        if(crosshair.transform.position.y <= yMin)
        {
            crosshair.transform.position = new Vector2(crosshair.transform.position.x, yMin);
        }

        if (crosshair.transform.position.x <= xMin)
        {
            crosshair.transform.position = new Vector2(xMin, crosshair.transform.position.y);
        }

        if (crosshair.transform.position.y >= yMax)
        {
            crosshair.transform.position = new Vector2(crosshair.transform.position.x, yMax);
        }

        if (crosshair.transform.position.x >= xMax)
        {
            crosshair.transform.position = new Vector2(xMax, crosshair.transform.position.y);
        }

        crosshair.transform.Translate(_vector * crosshairSpeed);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 inputPosition = Camera.main.ScreenToWorldPoint(eventData.position);

        Vector2 _vector = inputPosition - (Vector2)frame.transform.position;
        stick.transform.position = frame.transform.position + Vector3.ClampMagnitude(_vector, radius);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        stick.transform.localPosition = Vector3.zero;
    }
}
