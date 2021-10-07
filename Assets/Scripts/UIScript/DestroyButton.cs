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
            GameManager.Instance.isDestroy = false;
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            GameManager.Instance.isDestroy = true;
        }
    }
}
