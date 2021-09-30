using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 스킬 사용시 사운드 재생과 도착을 관장하는 스크립트

public class SkillIncoming : MonoBehaviour
{
    public AudioClip[] audioClip;
    AudioSource audioSource;
    Ground ground;

    public float speed;

    public float duration;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ground = GetComponent<Ground>();

        StartCoroutine(Incoming());
    }

    IEnumerator Incoming()
    {
        audioSource.PlayOneShot(audioClip[0]);
        transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        while (true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (1 / speed), transform.position.z);
            if (transform.position.y <= ground.transform.position.y)
                StartCoroutine(Duration());
            yield return null;
        }
    }

    IEnumerator Duration()
    {
        Debug.Log("지속시간: " + duration);
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
