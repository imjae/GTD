using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildClickManager : MonoBehaviour
{
    public Transform groundTransform;
    public GameObject tower;
    public void ClickBuildTower()
    {
        Instantiate(tower, groundTransform.position, groundTransform.rotation);
    }
    public void OnCancleClick()
    {
        Destroy(gameObject);
    }
}
