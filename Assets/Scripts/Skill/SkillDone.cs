using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDone : MonoBehaviour
{
    public float duration;
    float durationTime;
    float objectScale = 1f;

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
            gameObject.transform.localScale = new Vector3(objectScale, objectScale, objectScale);

            if (objectScale <= 0)
                Destroy(gameObject);
            objectScale -= 0.1f;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
