using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcBehaviour : MonoBehaviour
{
    private Orc orc;
    private Transform orcTransform;

    // Start is called before the first frame update
    void Start()
    {
        orc = GetComponent<Orc>();
        orcTransform = orc.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * orc.moveSpeed);
    }

}
