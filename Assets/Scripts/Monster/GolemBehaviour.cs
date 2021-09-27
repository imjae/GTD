using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemBehaviour : MonoBehaviour
{
    private Golem golem;
    private Transform golemTransform;

    // Start is called before the first frame update
    void Start()
    {
        golem = GetComponent<Golem>();
        golemTransform = golem.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * golem.moveSpeed);
    }

}
