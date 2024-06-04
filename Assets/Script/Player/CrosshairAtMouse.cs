using UnityEngine;
using YG;

public class CrosshairAtMouse : MonoBehaviour
{
    [SerializeField] float blockInXmax;
    [SerializeField] float blockInXmin;
    [SerializeField] float blockInYmax;
    [SerializeField] float blockInYmin;


    private void OnEnable() => YandexGame.GetDataEvent += GetData;
    private void OnDisable() => YandexGame.GetDataEvent -= GetData;

    bool isDeskop = false;


    private void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetData();
        }
    }

    private void GetData()
    {

        if (YandexGame.EnvironmentData.isDesktop)
            isDeskop = true;
    }

    private void FixedUpdate()
    {
        if (!isDeskop)
            return;

        Vector2 mousePosition = (Vector2)Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (mousePosition.y <= blockInYmin)
        {
            mousePosition.y = blockInYmin;
        }

        if (mousePosition.y >= blockInYmax)
        {
            mousePosition.y = blockInYmax;
        }

        if (mousePosition.x <= blockInXmin)
        {
            mousePosition.x = blockInXmin;
        }

        if (mousePosition.x >= blockInXmax)
        {
            mousePosition.x = blockInXmax;
        }

        transform.transform.position = new Vector3(mousePosition.x, mousePosition.y, -4.0f);
    }
}
