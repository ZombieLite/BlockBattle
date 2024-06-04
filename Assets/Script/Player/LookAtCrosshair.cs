using UnityEngine;

public class LookAtCrosshair : MonoBehaviour
{
    [SerializeField] GameObject crosshair;

    private void FixedUpdate()
    {
        LookAt2D(crosshair.transform.position);
    }

    public void LookAt2D(Vector3 lookTarget)
    {
        // the direction we want the X axis to face (from this object, towards the target)
        Vector3 xDirection = (lookTarget - transform.position).normalized;

        // Y axis is 90 degrees away from the X axis
        Vector3 yDirection = Quaternion.Euler(0, 0, 0) * xDirection;

        // Z should stay facing forward for 2D objects
        Vector3 zDirection = Vector3.forward;

        // apply the rotation to this object
        transform.rotation = Quaternion.LookRotation(zDirection, yDirection);
    }
}
