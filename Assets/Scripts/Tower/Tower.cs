using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    private void OnParticleCollision(GameObject other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
