using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class TextManager : MonoBehaviour
{
    TextMeshProUGUI text;
    string textName;
    
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        textName = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if(textName.Equals("MonsterCount"))
        {
            text.text = $"Count : {GameManager.Instance.currentMonsterCount}";
        }
        if(textName.Equals("CurrentGold"))
        {
            text.text = $"Gold : {GameManager.Instance.currentGold}";
        }
        if (textName.Equals("PlayTime"))
        {
            text.text = $"Time : {(int)GameManager.Instance.playTime}";
        }

    }
}
