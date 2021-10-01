using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundTest : MonoBehaviour
{

    public GameObject arrowtower;
    public GameObject cannontower;
    public GameObject magetower;
    public int towernum=1;
    public Ground[] grounds;

    private void Start()
    {
        grounds = FindObjectsOfType<Ground>();
    }

    public void Update()
    {
       // Debug.Log(towernum);
    }
}
