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
        if(GameManager.Instance.isBuild)
        {
            transform.Translate(Vector3.up * -1f);
        }
    }
    private void OnMouseDown()
    {
        if (GameManager.Instance.isBuild)
        {
            num = transform.parent.gameObject.GetComponent<groundTest>().towernum;
            Debug.Log(num);

            if (num == 1)
            {
                tower = transform.parent.gameObject.GetComponent<groundTest>().arrowtower;
                GameObject arrowTower = Instantiate(tower, transform.position, Quaternion.identity);
                arrowTower.transform.SetParent(GameObject.Find("Tower").transform.Find("ArrowTower"));
            }
            else if (num == 2)
            {
                tower = transform.parent.gameObject.GetComponent<groundTest>().cannontower;
                GameObject cannonTower = Instantiate(tower, transform.position, Quaternion.identity);
                cannonTower.transform.SetParent(GameObject.Find("Tower").transform.Find("CannonTower"));
            }
            else if (num == 3)
            {
                tower = transform.parent.gameObject.GetComponent<groundTest>().magetower;
                GameObject mageTower = Instantiate(tower, transform.position, Quaternion.identity);
                mageTower.transform.SetParent(GameObject.Find("Tower").transform.Find("MageTower"));
            }
        }
    }
    private void OnMouseExit()
    {
        if (GameManager.Instance.isBuild)
        {
            transform.Translate(Vector3.up * 1f);
        }
    }

}
