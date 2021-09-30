using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private GameObject tower;
    private int num=1;
    private void Start()
    {
        
    }
    private void OnMouseEnter()
    {
        transform.Translate(Vector3.up * -1f);
    }
    private void OnMouseDown()
    {
        //num = transform.parent.gameObject.GetComponent<groundTest>().towernum;
        Debug.Log(num);

        if (num == 1)
            tower = transform.parent.gameObject.GetComponent<groundTest>().arrowtower;
        else if (num == 2)
            tower = transform.parent.gameObject.GetComponent<groundTest>().cannontower;
        else if (num == 3)
            tower = transform.parent.gameObject.GetComponent<groundTest>().magetower;
        Instantiate(tower, transform.position, Quaternion.identity);
    }
    private void OnMouseExit()
    {
        transform.Translate(Vector3.up * 1f);
    }

}
