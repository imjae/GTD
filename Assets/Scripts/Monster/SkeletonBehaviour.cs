using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBehaviour : MonoBehaviour
{
    private Skeleton skeleton;
    private Transform skeletonTransform;

    // Start is called before the first frame update
    void Start()
    {
        skeleton = GetComponent<Skeleton>();
        skeletonTransform = skeleton.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * skeleton.moveSpeed);
    }
}
