using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBehaviour : MonoBehaviour
{
    private Dragon dragon;
    private Transform dragonTransform;

    // Start is called before the first frame update
    void Start()
    {
        dragon = GetComponent<Dragon>();
        dragonTransform = dragon.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * dragon.moveSpeed);
    }

}
