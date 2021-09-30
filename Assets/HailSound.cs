using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HailSound : MonoBehaviour
{
    public AudioClip[] audioClip;
    AudioSource audioSource;
    ParticleSystem particle;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        particle = GetComponent<ParticleSystem>();
        StartCoroutine(ShootingSound());
    }

    IEnumerator ShootingSound()
    {
        while (true)
        {
            if (particle.isEmitting)
            {
                audioSource.PlayOneShot(audioClip[Random.Range(0, 1)]);
                yield return new WaitForSeconds(Random.Range(0f, 1f));
            }
        }
    }
}
