using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private void FixedUpdate()
    {
        Vector2 mousePosition = (Vector2)Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        float angle = Vector2.Angle(Vector2.right, mousePosition - (Vector2)transform.position);

        if (angle < 27 || angle > 137 || transform.position.y > mousePosition.y)
            return;

        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);
    }
}
