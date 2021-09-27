using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Map : MonoBehaviour
{
    public GameObject slime;
    public Transform respawnPoint;

    public GameObject parent;

    [SerializeField] 
    private SlimeMonsterFactory smf = null;
    
    public Vector3[] wayPoint = new Vector3[]{
        new Vector3(45f, -0.5f, -26.89f),
        new Vector3(45f, -0.5f, -56.89f),
        new Vector3(-75f, -0.5f, -56.89f),
        new Vector3(-75f, -0.5f, 3.1f),
        new Vector3(45f, -0.5f, -26.89f)
    };


    void Start()
    {
        InvokeRepeating("CreateMonster", 1f, 5f);
    }

    void Update()
    {
        
    }

    private void CreateMonster()
    {
        this.smf.Spawn(parent.transform, respawnPoint.localPosition);

        if (GameManager.Instance.playTime >= 100f)
            CancelInvoke("CreateSlime");
    }
}
