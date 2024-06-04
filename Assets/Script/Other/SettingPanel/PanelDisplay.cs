using UnityEngine;

public class PanelDisplay : MonoBehaviour
{
    private void OnEnable()
    {
        ListPanel.PanelListOn(gameObject);
    }

    public void SetEnabled()
    {
        if (gameObject.activeSelf)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }
}
