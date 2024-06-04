using UnityEngine;

public class CubeTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            Core.GameOver?.Invoke();
            Destroy(gameObject);
        }
    }
}