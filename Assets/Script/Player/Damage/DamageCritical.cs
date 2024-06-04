using UnityEngine;

public class DamageCritical : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 0.6f);
    }
}
