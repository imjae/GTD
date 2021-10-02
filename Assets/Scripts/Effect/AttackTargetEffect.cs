using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTargetEffect : MonoBehaviour
{
    float effectTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        effectTime += Time.deltaTime;

        if (effectTime >= 4f)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {

    }
}
