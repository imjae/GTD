using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttckMonster : MonoBehaviour
{
    public GameObject arrow;
    public GameObject StartPoint;
    public GameObject monster;
    public float attackSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            StartCoroutine(AttackMonster(other.gameObject));
        }
    }
    private void OnTriggerExit(Collider other)
    {
    }
    void Attack()
    {
        var myArrow = Instantiate(arrow, StartPoint.transform.position, StartPoint.transform.rotation);
        //StartPoint.transform.LookAt(target.transform.position);
        myArrow.GetComponent<Rigidbody>().AddForce(StartPoint.transform.forward * 1000);
    }
    IEnumerator AttackMonster(GameObject target)
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            var myArrow = Instantiate(arrow, StartPoint.transform.position, StartPoint.transform.rotation);
            yield return new WaitForSeconds(attackSpeed);
            StartPoint.transform.LookAt(target.transform.position);
            myArrow.GetComponent<Rigidbody>().AddForce(StartPoint.transform.forward * 1000);
        }
    }
}
