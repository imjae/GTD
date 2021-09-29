using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    private Monster monster;
    private Transform monsterTransform;
    private GameObject healthBar;
    private HealthSystem healthSystem;

    private Animator animator;

    bool isDie = false;

    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<Monster>();
        monsterTransform = monster.transform;
        healthBar = transform.Find("Canvas").Find("HealthBar").gameObject;
        healthSystem = healthBar.GetComponent<HealthSystem>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healthSystem.hitPoint <= 0 && isDie == false)
        {
            isDie = true;
            animator.SetTrigger("DieTrigger");
        }
    }

    private void FixedUpdate()
    {
        if(!isDie)
            monsterTransform.Translate(Vector3.forward * monster.moveSpeed);
    }

    public void MonsterDestroy()
    {
        Destroy(gameObject);
    }
}
