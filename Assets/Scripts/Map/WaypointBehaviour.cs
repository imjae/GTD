using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointBehaviour : MonoBehaviour
{
    string currentName;
    float distance;

    public GameObject[] wayPoint;

    private void Start()
    {
        currentName = gameObject.name;
    }

    private void OnTriggerStay(Collider other)
    {
        // Debug.Log($"{other.gameObject.transform.parent.gameObject.name} 충돌!!");
        if (other.gameObject.tag == "Monster")
        {
            // targetBodyObject는 몬스터의 body컴포넌트
            GameObject targetBodyObject = other.gameObject;
            Transform targetBodyTransform = targetBodyObject.transform;
            // targetObject는 몬스터 자체 컴포넌트
            GameObject targetObject = targetBodyTransform.parent.gameObject;
            Transform targetTransform = targetObject.transform;

            distance = Vector3.Distance(gameObject.transform.position, targetTransform.position);

            if (distance < 0.2f)
            {
                targetObject.GetComponent<Animator>().SetTrigger("RunTrigger");
               
                if (currentName.Equals("WayPoint1"))
                {
                    // Debug.Log("waypoint1 통과");
                    targetTransform.LookAt(wayPoint[1].transform);
                }
                else if (currentName.Equals("WayPoint2"))
                {
                    // Debug.Log("waypoint2 통과");
                    targetTransform.LookAt(wayPoint[2].transform);
                }
                else if (currentName.Equals("WayPoint3"))
                {
                    // Debug.Log("waypoint3 통과");
                    targetTransform.LookAt(wayPoint[3].transform);
                }
                else if (currentName.Equals("WayPoint4"))
                {
                    // Debug.Log("waypoint4 통과");
                    targetTransform.LookAt(wayPoint[4].transform);
                }
                else if (currentName.Equals("WayPoint5"))
                {
                    // Debug.Log("waypoint5 통과");
                    targetTransform.LookAt(wayPoint[1].transform);
                }
            }
        }
    }
}
