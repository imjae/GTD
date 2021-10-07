using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public float DestroyTime = 0.5f;

    void Start()
    {
        Destroy(gameObject, DestroyTime);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
            Destroy(gameObject);
        else if (other.CompareTag("TowerGround"))
            Destroy(gameObject);
    }
}