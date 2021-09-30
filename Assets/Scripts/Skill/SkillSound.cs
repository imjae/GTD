using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 스킬 사용시 사운드 재생 오브젝트를 생성하는 스크립트

public class SkillSound : MonoBehaviour
{
    public GameObject soundObject;

    public bool destroyWhenDone = true;
    public bool soundObjectIsChild = false;

    void Start()
    {
        GameObject madeObject = Instantiate(soundObject, transform.position, Quaternion.identity);
        AudioSource madeSource = madeObject.GetComponent<AudioSource>();

        if (soundObjectIsChild)
            madeObject.transform.SetParent(transform);

        if (destroyWhenDone)
        {
            Destroy(madeObject, madeSource.clip.length);
        }
    }
}