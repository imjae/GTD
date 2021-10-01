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
            ColorBlock cb = button.colors;
            Color newColor = Color.white;
            cb.normalColor = newColor;
            cb.selectedColor = newColor;
            button.colors = cb;
            GameManager.Instance.isDestroy = false;
        }
        else
        {
            ColorBlock cb = button.colors;
            Color newColor = Color.red;
            cb.normalColor = newColor;
            button.colors = cb;
            GameManager.Instance.isDestroy = true;
        }
    }
}
