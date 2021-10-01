using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBuildButton : MonoBehaviour
{
    public GameObject buttonGroup;
    public GameObject buttonUI;
    // Start is called before the first frame update

    private void Start()
    {
        
    }

    public void ShowButton()
    {
        buttonUI.SetActive(!buttonUI.activeSelf);
        buttonGroup.SetActive(!buttonGroup.activeSelf);
        GameManager.Instance.isBuild = true;
    }
    public void ShowSkillButton()
    {
        buttonUI.SetActive(!buttonUI.activeSelf);
        buttonGroup.SetActive(!buttonGroup.activeSelf);
    }
}
