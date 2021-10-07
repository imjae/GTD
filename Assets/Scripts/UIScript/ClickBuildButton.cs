using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBuildButton : MonoBehaviour
{
    public GameObject buildButtonGroup;
    public GameObject skillButtonGroup;
    public GameObject uiButtonGroup;
    // Start is called before the first frame update

    public void ShowBuildButton()
    {
        buildButtonGroup.SetActive(true);
        skillButtonGroup.SetActive(false);
        uiButtonGroup.SetActive(false);
        GameManager.Instance.isBuild = true;
    }
    public void ShowSkillButton()
    {
        skillButtonGroup.SetActive(true);
        buildButtonGroup.SetActive(false);
        uiButtonGroup.SetActive(false);
    }
}
