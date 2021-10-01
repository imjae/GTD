using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ų ���� ���� ����� ������ �����ϴ� ��ũ��Ʈ

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
       /* speed = GetComponent<Skill>().speed;
        duration = GetComponent<Skill>().duration;*/
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
        Debug.Log("���ӽð�: " + duration);
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
