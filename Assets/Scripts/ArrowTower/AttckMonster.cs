using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttckMonster : MonoBehaviour
{
    public GameObject arrow;
    public GameObject StartPoint;
    public float attackSpeed;
    bool isAttack = false;
    AudioSource source;
    public AudioClip[] clip;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            if (!isAttack)
                StartCoroutine(AttackMonster(other.gameObject));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isAttack = false;
    }
    void Attack()
    {
        var myArrow = Instantiate(arrow, StartPoint.transform.position, StartPoint.transform.rotation);
        //StartPoint.transform.LookAt(target.transform.position);
        myArrow.GetComponent<Rigidbody>().AddForce(StartPoint.transform.forward * 1000);
    }
    IEnumerator AttackMonster(GameObject target)
    {
        isAttack = true;
        while (true)
        {
            if (!isAttack)
                break;
            source.PlayOneShot(clip[0]);
            var myArrow = Instantiate(arrow, StartPoint.transform.position, StartPoint.transform.rotation);
            StartPoint.transform.LookAt(target.transform.position);
            myArrow.GetComponent<Rigidbody>().AddForce(StartPoint.transform.forward * 2000);
            yield return new WaitForSeconds(attackSpeed);
        }
    }
}
