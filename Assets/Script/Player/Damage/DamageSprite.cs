using UnityEngine;
using UnityEngine.U2D;

public class DamageSprite : MonoBehaviour
{
    [SerializeField] SpriteAtlas atlas;
    [SerializeField] GameObject num;

    public void SpriteShowDamage(int damage)
    {
        string strDamage;
        int strLength;

        strDamage = damage.ToString();
        strLength = strDamage.Length;

        for (int i = 0; i < strLength; i++)
        {
            GameObject _sprite;
            _sprite = Instantiate(num, gameObject.transform);
            _sprite.transform.localPosition = new Vector2(transform.position.x + ((i + 1) * 2), transform.position.y);

            string strNewText = "Damage_";
            strNewText += strDamage[i];

            _sprite.GetComponent<SpriteRenderer>().sprite = atlas.GetSprite(strNewText);
        }
        Destroy(num);
        Destroy(gameObject, 0.6f);
    }
}
