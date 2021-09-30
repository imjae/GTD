using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDone : MonoBehaviour
{
    public float duration;
    float durationTime;

    void Start()
    {
        durationTime = Time.deltaTime + duration;
        StartCoroutine(Duration());
    }

    IEnumerator Duration()
    {
        Debug.Log("지속시간: " + duration);
        while (true)
        {
            gameObject.transform.localScale /= (Time.deltaTime / durationTime);
            if (durationTime <= Time.deltaTime)
                Destroy(gameObject);
            yield return null;
        }
    }
}
