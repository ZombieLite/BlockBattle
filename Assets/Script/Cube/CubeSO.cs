using UnityEngine;

[CreateAssetMenu(menuName = "ZL/Cube", fileName = "Cube")]
public class CubeSO : ScriptableObject
{
    [SerializeField] int health;
    public int Health
    {
        get { return health; }
        protected set { }
    }

    [SerializeField] Color32 color;

    public Color32 GetColor
    {
        get { return color; }
        protected set { }
    }
}
