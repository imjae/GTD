using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildArrowTower : MonoBehaviour
{
    public enum TOWER_TYPE { DEFAULT_TOWER, ARROW_TOWER}

    public TOWER_TYPE towerType;
    // Start is called before the first frame update
    public int towerNum = 0;
    public GameObject ground;

    public void MakeNumArrowTower()
    {
        towerNum = 1;
        ground.GetComponent<groundTest>().towernum = towerNum;
    }

}
