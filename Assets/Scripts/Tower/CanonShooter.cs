using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShooter : MonoBehaviour
{
    public float shootRate = 3;
    public GameObject bullet;
    public AudioClip[] audioClip;
    AudioSource audioSource;
    float playTime = 0f;

    Vector3 target;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            CanonShoot();
    }

    private void FixedUpdate()
    {
        playTime = Time.time;
    }

    void OnTriggerStay(Collider other)
    {
        if(playTime % 2 == 0)
        {
            if (other.gameObject.CompareTag("Target"))
            {
                target = other.gameObject.transform.position;
                Debug.Log("Target On");
                transform.LookAt(other.transform);
                CanonShoot();
            }
        }
    }

    void CanonShoot()
    {
        audioSource.PlayOneShot(audioClip[0]);
        GameObject tmpBullet = Instantiate(bullet, transform.position, transform.rotation);
        tmpBullet.GetComponent<CanonBullet>().target = this.target;
    }
}
