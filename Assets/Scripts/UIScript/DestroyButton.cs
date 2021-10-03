using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DestroyButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;
    public void GetDestroyObject()
    {
        if (GameManager.Instance.isDestroy == true)
        {
            GetComponent<Image>().color = Color.white;
            /*ColorBlock cb = button.colors;
            Color newColor = Color.white;
            cb.normalColor = newColor;
            cb.selectedColor = newColor;
            button.colors = cb;*/
            GameManager.Instance.isDestroy = false;
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            /*Color color = ;
            ColorBlock cb = button.colors;
            Color newColor = Color.red;
            cb.normalColor = newColor;
            button.colors = cb;*/
            GameManager.Instance.isDestroy = true;
        }
    }
}
