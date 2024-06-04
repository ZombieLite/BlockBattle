using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] List<GameObject> objPoint;

    float speed = 7.0f;

    private void Start()
    {
        StartCoroutine(CubeSpawnManager());
    }

    IEnumerator CubeSpawnManager()
    {
        yield return new WaitForSeconds(1.0f);

        float _speed;

        while(true)
        {
            _speed = speed - (float)CubeWave.GetWave() / 10.0f;

            if (_speed <= 1.0)
                _speed = 1.0f;

            GameObject _cube = Instantiate(cube);
            _cube.transform.position = (Vector2)objPoint[Random.Range(0, objPoint.Count)].transform.position;
            yield return new WaitForSeconds(_speed);
        }
    }
}
