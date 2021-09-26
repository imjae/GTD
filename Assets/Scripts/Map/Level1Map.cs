using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Map : MonoBehaviour
{
    public GameObject slime;
    public Transform respawnPoint;

    public Vector3[] wayPoint = new Vector3[]{
        new Vector3(45f, -0.5f, -26.89f),
        new Vector3(45f, -0.5f, -56.89f),
        new Vector3(-75f, -0.5f, -56.89f),
        new Vector3(-75f, -0.5f, 3.1f),
        new Vector3(45f, -0.5f, -26.89f)
    };


    void Start()
    {
        GeneratedMonster(slime).transform.SetParent(transform.Find("Monster"));
    }

    void Update()
    {
        
    }

    GameObject GeneratedMonster(GameObject monster)
    {
        return Instantiate(monster, respawnPoint.position, Quaternion.Euler(0f, -90f, 0f));
    }
}
