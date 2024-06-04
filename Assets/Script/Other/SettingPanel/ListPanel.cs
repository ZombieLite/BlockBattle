using System.Collections.Generic;
using UnityEngine;

public class ListPanel : MonoBehaviour
{
    [SerializeField] List<GameObject> listPanel;

    private static List<GameObject> _list;

    private void Start()
    {
        _list = listPanel;
    }

    public static void PanelListOn(GameObject panel)
    {
        if (panel == null)
            return;

        if (_list.Count == 0)
            return;

        foreach(GameObject pnl in _list)
        {
            if (pnl == panel)
                continue;

            pnl.SetActive(false);
        }
    }
}
