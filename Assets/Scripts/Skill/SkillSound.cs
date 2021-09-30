using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 스킬 사용시 사운드 재생 오브젝트를 생성하는 스크립트

public class SkillSound : MonoBehaviour
{
    public GameObject soundObject;

    public bool destroyWhenDone = true;
    public bool soundObjectIsChild = false;

    [Range(0.01f, 10f)]
    public float randomPitch = 1f;

    void Start()
    {
        GameObject madeObject = Instantiate(soundObject, transform.position, Quaternion.identity);
        AudioSource madeSource = madeObject.GetComponent<AudioSource>();

        if (soundObjectIsChild)
            madeObject.transform.SetParent(transform);

        if (randomPitch != 1)
        {
            if (Random.value < .5)
                madeSource.pitch *= Random.Range(1 / randomPitch, 1);
            else
                madeSource.pitch *= Random.Range(1, randomPitch);
        }

        if (destroyWhenDone)
        {
            float duration = madeSource.clip.length / madeSource.pitch;
            Destroy(madeObject, duration);
        }
    }
}