using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class MonsterCount : MonoBehaviour
{
    TextMeshProUGUI countText;
    
    void Start()
    {
        countText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = $"Count : {GameManager.Instance.currentMonsterCount}";
    }
}
