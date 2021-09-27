using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBullet : MonoBehaviour
{
    public AudioClip[] audioClip;
    AudioSource audioSource;

    Rigidbody body;
    MeshRenderer rend;
    SphereCollider col;

    float afterShotTime;

    public Vector3 target;

    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody>();
        rend = GetComponent<MeshRenderer>();
        col = GetComponent<SphereCollider>();
    }

    void OnEnable()
    {
        afterShotTime = Time.time + 5f;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, this.target, 0.05f);
        if (afterShotTime < Time.time)
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Bullet"))
            StartCoroutine(CanonHit()); 
    }

    IEnumerator CanonHit()
    {
        audioSource.PlayOneShot(audioClip[Random.Range(0, 2)]);
        rend.enabled = false;
        col.enabled = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
