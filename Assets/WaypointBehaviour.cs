using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointBehaviour : MonoBehaviour
{
    string currentName;

    private void Start()
    {
        currentName = gameObject.name;
    }

    private void OnTriggerStay(Collider other)
    {
        // targetBodyObject는 몬스터의 body컴포넌트
        GameObject targetBodyObject = other.gameObject;
        Transform targetBodyTransform = targetBodyObject.transform;
        // targetObject는 몬스터 자체 컴포넌트
        GameObject targetObject = targetBodyTransform.parent.gameObject;
        Transform targetTransform = targetObject.transform;

        float distance = Vector3.Distance(gameObject.transform.position, targetTransform.position);

        Debug.Log(distance);

        if(distance < 0.15f)
        {
            if (currentName.Equals("Waypoint1"))
            {
                // Debug.Log("waypoint1 통과");
                targetTransform.localRotation = Quaternion.Euler(0f, -180f, 0f);
            }
            else if (currentName.Equals("Waypoint2"))
            {
                // Debug.Log("waypoint2 통과");
                targetTransform.localRotation = Quaternion.Euler(0f, -90f, 0f); ;
            }
            else if (currentName.Equals("Waypoint3"))
            {
                // Debug.Log("waypoint3 통과");
                targetTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if (currentName.Equals("Waypoint4"))
            {
                // Debug.Log("waypoint4 통과");
                targetTransform.localRotation = Quaternion.Euler(0f, 90f, 0f);
            }
            else if (currentName.Equals("Waypoint5"))
            {
                // Debug.Log("waypoint5 통과");
                targetTransform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }
    }
}
