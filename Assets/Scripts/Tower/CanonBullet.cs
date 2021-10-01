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
    ParticleSystem[] particles;

    float afterShotTime;

    public Vector3 target;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody>();
        rend = GetComponent<MeshRenderer>();
        col = GetComponent<SphereCollider>();
        particles = GetComponentsInChildren<ParticleSystem>();
    }

    void OnEnable()
    {
        afterShotTime = Time.time + 5f;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, this.target, 0.1f);
        if (afterShotTime < Time.time)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Bullet") && !other.gameObject.CompareTag("Tower"))
            StartCoroutine(CanonHit());
    }

    IEnumerator CanonHit()
    {
        audioSource.PlayOneShot(audioClip[Random.Range(0, 2)]);
        particles[0].Play();
        particles[1].Play();
        particles[2].Play();
        rend.enabled = false;
        col.enabled = false;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
