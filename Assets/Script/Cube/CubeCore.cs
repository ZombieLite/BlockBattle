using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeCore : MonoBehaviour
{
    [SerializeField] GameObject text;
    [SerializeField] GameObject img;
    [SerializeField] GameObject cubeWave;
    [SerializeField] List<CubeSO> listSo;

    decimal health;
    static string[] names = { "", "K", "M", "B", "T" };

    private void Start()
    {
        
        int rnd = Random.Range(0, 5);

        if (rnd == 0) CubePreset(0);
        else if (rnd == 1) CubePreset(1);
        else CubePreset(2);
    }

    private void CubePreset(int id)
    {

        img.GetComponent<SpriteRenderer>().color = listSo[id].GetColor;
        int _health = listSo[id].Health * CubeWave.GetWave();

        SetCubeHealth(_health);
    }

    public decimal GetCubeHealth()
    {
        return health;
    }

    public void SetCubeHealth(decimal _health)
    {
        if(_health <= 0)
        {
            float exp = LevelPlayer.instance.GetLevel() * AbilityExp.GetExp();
            LevelPlayer.instance.AddExp((int)Mathf.Round(exp));
            CubeWave.AddProgress(1);
            Destroy(gameObject);
            return;
        }

        health = _health;

        if (health < 10000)
        {
            text.GetComponent<TextMeshPro>().fontSize = 3;
        }
        else
        {
            text.GetComponent<TextMeshPro>().fontSize = 2;
        }
        text.GetComponent<TextMeshPro>().text = FormatNubmer(health);
    }

    static string FormatNubmer(decimal digit)
    {
        int n = 0;
        while (n + 1 < names.Length && digit >= 1000m)
        {
            digit /= 1000m;
            n++;
        }
        return string.Format("{0}{1}", digit, names[n]);
    }
}
