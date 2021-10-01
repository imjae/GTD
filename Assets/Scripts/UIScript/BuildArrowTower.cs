using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildArrowTower : MonoBehaviour
{
    // Start is called before the first frame update
    public int towerNum = 0;
    public GameObject ground;
    void Start()
    {
        
    }
    public void MakeNumArrowTower()
    {
        towerNum = 1;
        ground.GetComponent<groundTest>().towernum = towerNum;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
