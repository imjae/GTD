using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private GameObject tower;

    private void Start()
    {
        tower = transform.parent.gameObject.GetComponent<groundTest>().tower;
    }

    private void OnMouseEnter()
    {
        transform.Translate(Vector3.up * -1f);
    }
    private void OnMouseDown()
    {
        Instantiate(tower, transform.position, Quaternion.identity);
    }
    private void OnMouseExit()
    {
        transform.Translate(Vector3.up * 1f);
    }

}
