using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArrowTowerScript : MonoBehaviour
{
    public GameObject arrow;
    public GameObject StartPoint;
    public GameObject monster;
    public string enemyTag = "Monster";
    public float attackRange = 15f;
    public Transform target;
    public int attackSpeed;
    void Start()
    {
        InvokeRepeating("Attack", 1, attackSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //InvokeRepeating("Attack", 1,5);
    }
    void Attack()
    {
        var myArrow = Instantiate(arrow, StartPoint.transform.position, StartPoint.transform.rotation);
        StartPoint.transform.LookAt(target.transform.position);
        myArrow.GetComponent<Rigidbody>().AddForce(StartPoint.transform.forward * 1000);
    }
}
