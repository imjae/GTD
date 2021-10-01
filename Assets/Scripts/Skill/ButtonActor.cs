using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActor : MonoBehaviour
{
    Image image;
    Button button;
    public GameObject skill;
    public GameObject target;
    float coolTime;
    float leftTime;
    float fillRatio;

    void Start()
    {
        button = GetComponent<Button>();
        coolTime = skill.GetComponent<Skill>().rate;
        button.onClick.AddListener(UseSkill);
    }

    void UseSkill()
    {
        Debug.Log(gameObject.name + " ���");
        leftTime = coolTime;
        button.enabled = false;
        transform.localScale /= 1.2f;
        image.color = new Color(1f, 1f, 1f, 0.8f);
        target.SetActive(true);
        StartCoroutine(CoolTime());
    }

    void Update()
    {
        if (isClicked)
        {
            leftTime -= Time.deltaTime;
            fillRatio = 1f - (leftTime / coolTime);
            image.fillAmount = fillRatio;
            yield return null;

            if (leftTime <= 0)
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
