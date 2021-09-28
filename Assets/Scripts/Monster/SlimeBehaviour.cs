using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour
{
    private Slime slime;
    private Transform slimeTransform;


    // Start is called before the first frame update
    void Start()
    {
        slime = GetComponent<Slime>();
        slimeTransform = slime.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * slime.moveSpeed);
    }

}
