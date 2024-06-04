using UnityEngine;
using UnityEngine.UI;

public class ReplacePlus : MonoBehaviour
{
    [SerializeField] Sprite maxImage;
    [SerializeField] Sprite PlusImage;
    
    public void ReplaceImageInPlus()
    {
        gameObject.GetComponent<Image>().sprite = PlusImage;
        RectTransformExtensions.SetHeight(gameObject.GetComponent<RectTransform>(), 15);
        RectTransformExtensions.SetWidth(gameObject.GetComponent<RectTransform>(), 20);
    }

    public void ReplaceImageInMax()
    {
        gameObject.GetComponent<Image>().sprite = maxImage;
        RectTransformExtensions.SetHeight(gameObject.GetComponent<RectTransform>(), 15);
        RectTransformExtensions.SetWidth(gameObject.GetComponent<RectTransform>(), 30);
    }
}
