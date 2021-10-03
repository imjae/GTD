using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShooter : MonoBehaviour
{
    public float shootRate = 3;
    public GameObject bullet;
    public AudioClip[] audioClip;
    AudioSource audioSource;
    Animator animator;
    ParticleSystem particle;
    float playTime = 0f;

    Vector3 target;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponentInParent<Animator>();
        particle = GetComponentInChildren<ParticleSystem>();
    }



    private void FixedUpdate()
    {
        playTime = Time.time;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Monster")
        {
            if (playTime % 1.5 == 0)
            {
                target = other.gameObject.transform.position;
                CanonShoot();
            }
        }

    }

    void CanonShoot()
    {
        audioSource.PlayOneShot(audioClip[0]);
        animator.Play("CanonTower", -1, 0f);
        particle.Play();
        GameObject tmpBullet = Instantiate(bullet, transform.position, transform.rotation);
        tmpBullet.GetComponent<CanonBullet>().target = this.target;
    }
}
