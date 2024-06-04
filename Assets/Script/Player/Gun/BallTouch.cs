using UnityEngine;

public class BallTouch : MonoBehaviour
{
    [SerializeField] GameObject pongExplosion;
    [SerializeField] GameObject damageNumeration;
    [SerializeField] GameObject prefabCritical;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            BallEffect();
            Destroy(gameObject);
        }

        if(collision.tag == "Enemy")
        {
            Vector2 vector = collision.transform.position - transform.position;
            vector.Normalize();

            

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(vector * KnockBack(), ForceMode2D.Impulse);

            Damage(collision);
            BallEffect();
            Destroy(gameObject);
        }
    }

    private float KnockBack()
    {
        float _knockback = 0.0f;
        _knockback = 0.5f + AbilityKnockback.GetKnockback();
        return _knockback;
    }

    private void Damage(Collider2D collision)
    {
        int damage = Random.Range(1, 4) + AbilityDamage.GetDamage();

        float rnd = Random.Range(0.0f, 100.0f);

        if(rnd <= AbilityCritical.GetCritical())
        {
            damage *= 2;

            GameObject _crit = Instantiate(prefabCritical);
            _crit.transform.position = transform.position;
        }

        collision.GetComponent<CubeCore>().SetCubeHealth(collision.GetComponent<CubeCore>().GetCubeHealth() - damage);

        GameObject dmgNum;
        dmgNum = Instantiate(damageNumeration);
        dmgNum.transform.position = transform.position;

        dmgNum.GetComponent<DamageSprite>().SpriteShowDamage(damage);
    }

    private void BallEffect()
    {
        GameObject expl = Instantiate(pongExplosion);
        expl.transform.position = transform.position;
        expl.GetComponent<AudioSource>().pitch = Random.Range(0.7f, 1.2f);
        expl.GetComponent<AudioSource>().Play();

        Destroy(expl, 1.0f);
    }
}
