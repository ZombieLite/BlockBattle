using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject gun1;
    [SerializeField] GameObject gun2;
    [SerializeField] GameObject ball;

    private float timer, speed = 2.0f;
    private bool changeGun = false;

    private void FixedUpdate()
    {
        if (timer <= Time.time)
        {
            pBallAttack();
            timer = Time.time + speed - AbilitySpeed.GetSpeed();
        }
    }

    private void pBallAttack()
    {
        GameObject gun;
        if (!changeGun)
            gun = gun1;
        else
            gun = gun2;

        gun = gun.transform.GetChild(0).gameObject;
            
        
        GameObject _ball = Instantiate(ball);
        _ball.transform.position = gun.transform.position;
        

        Rigidbody2D rb = _ball.GetComponent<Rigidbody2D>();
        rb.rotation = gun.transform.eulerAngles.z + 90;
        rb.AddRelativeForce(Vector2.right * BallSpeedManager(), ForceMode2D.Impulse);

        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.pitch = Random.Range(0.8f, 1.1f);
        audio.Play();

        Destroy(_ball, 3.0f);
        changeGun = !changeGun;
    }
    private float BallSpeedManager()
    {
        float _speed = 2.0f;
        float _addSpeed;

        _addSpeed = _speed - speed;
        _speed += _addSpeed;

        _speed *= 2.0f;
        return _speed;
    }

    public float GetBallSpeed()
    {
        return speed;
    }

    public void SetBallSpeed(float _speed)
    {
        speed = _speed;
    }
}
