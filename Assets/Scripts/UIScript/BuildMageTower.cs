using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMageTower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ground;
    public int towerNum = 0;
    void Start()
    {
        
    }
    public void MakeNumMageTower()
    {
        towerNum = 3;
        ground.GetComponent<groundTest>().towernum = towerNum;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
