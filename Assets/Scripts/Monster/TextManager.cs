using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class TextManager : MonoBehaviour
{
    TextMeshProUGUI text;
    string name;
    
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        name = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if(name.Equals("MonsterCount"))
        {
            text.text = $"Count : {GameManager.Instance.currentMonsterCount}";
        }
        if(name.Equals("CurrentGold"))
        {
            text.text = $"Gold : {GameManager.Instance.currentGold}";
        }
        if (name.Equals("PlayTime"))
        {
            text.text = $"Time : {(int)GameManager.Instance.playTime}";
        }

    }
}
