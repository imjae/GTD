using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExplosion : MonoBehaviour
{
    private ParticleSystem system;

    private void Start()
    {
        system = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!system.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
