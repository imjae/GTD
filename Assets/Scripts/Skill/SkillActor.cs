using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillActor : MonoBehaviour
{
    public GameObject skill1;
    public Transform target;
    int layerMask;
    void Start()
    {
        //gameObject.SetActive(false);
        layerMask = 1 << LayerMask.NameToLayer("Ground") | ~(1 << LayerMask.NameToLayer("Monster"));
    }

    void Update()
    {
        Ray ray = Camera.allCameras[1].ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f, layerMask))
        {
            target.position = new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse");
            Instantiate(skill1, target.position, Quaternion.identity);
        }
    }

    void ButtonPress()
    {
        gameObject.SetActive(true);
    }
}
