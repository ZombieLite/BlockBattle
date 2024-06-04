using UnityEngine;
using YG;

public class testt : MonoBehaviour
{
    [SerializeField] GameObject _test;
    private void OnEnable()
    {
        GameObject expl = Instantiate(_test);
        //expl.transform.position = transform.position;
    }
}
