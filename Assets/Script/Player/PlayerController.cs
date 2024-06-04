using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (!Input.anyKey)
            return;

        float _horizontal = Input.GetAxis("Horizontal");

        _horizontal *= 20.0f;

        Vector2 dirY = new Vector2(_horizontal, 0);
        dirY = transform.TransformDirection(dirY) * speed * Time.fixedDeltaTime;
        gameObject.GetComponent<Rigidbody2D>().velocity = dirY;
    }
}
