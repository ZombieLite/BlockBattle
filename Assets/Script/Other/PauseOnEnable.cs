using UnityEngine;

public class PauseOnEnable : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
