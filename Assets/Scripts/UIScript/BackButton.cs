using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject uiButtonGroup;
    public GameObject buildButtonGroup;
    public GameObject skillButtonGroup;

    public void ShowBuildButton()
    {
        uiButtonGroup.SetActive(true);
        buildButtonGroup.SetActive(false);
        skillButtonGroup.SetActive(false);
        GameManager.Instance.isBuild = false;
    }
}
