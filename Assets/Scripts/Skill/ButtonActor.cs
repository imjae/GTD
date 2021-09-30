using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActor : MonoBehaviour
{
    public Image image;
    public Button button;
    public float coolTime = 10f;
    public bool isClicked = false;
    float leftTime = 10f;
    float speed = 5f;

    void Start()
    {
        button = GetComponent<Button>();
        //button.onClick.AddListener(ClickButton);
    }

    void Update()
    {
        if (isClicked)
        {
            if (leftTime > 0)
            {
                leftTime -= Time.deltaTime * speed;
                if (leftTime < 0)
                {
                    leftTime = 0;
                    if (button)
                        button.enabled = true;
                    isClicked = true;
                }
                float ratio = 1f - (leftTime / coolTime);
                if (image)
                    image.fillAmount = ratio;
            }
        }
    }

    public void StartCoolTime()
    {
        leftTime = coolTime;
        isClicked = true;
        if (button)
            button.enabled = false;
    }

    //void ClickButton()
    //{
    //    Debug.Log(gameObject.name);
    //    transform.localScale = new Vector3(0.9f, 0.9f, 1);
    //}
}
