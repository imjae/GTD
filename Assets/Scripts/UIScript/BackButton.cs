using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject buttonUI;
    public GameObject buttonGroup;

    public void ShowBuildButton()
    {
        buttonUI.SetActive(!buttonUI.activeSelf);
        buttonGroup.SetActive(!buttonGroup.activeSelf);
        GameManager.Instance.isBuild = false;
    }
}
