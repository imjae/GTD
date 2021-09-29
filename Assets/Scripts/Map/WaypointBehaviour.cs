using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointBehaviour : MonoBehaviour
{
    string currentName;
    float distance;

    private void Start()
    {
        currentName = gameObject.name;
    }

    private void OnTriggerStay(Collider other)
    {
        // Debug.Log($"{other.gameObject.transform.parent.gameObject.name} �浹!!");
        if (other.gameObject.tag == "Monster")
        {
            // targetBodyObject�� ������ body������Ʈ
            GameObject targetBodyObject = other.gameObject;
            Transform targetBodyTransform = targetBodyObject.transform;
            // targetObject�� ���� ��ü ������Ʈ
            GameObject targetObject = targetBodyTransform.parent.gameObject;
            Transform targetTransform = targetObject.transform;

            distance = Vector3.Distance(gameObject.transform.position, targetTransform.position);

            if (distance < 0.15f)
            {
                if (currentName.Equals("Waypoint1"))
                {
                    // Debug.Log("waypoint1 ���");
                    targetTransform.localRotation = Quaternion.Euler(0f, -180f, 0f);
                }
                else if (currentName.Equals("Waypoint2"))
                {
                    // Debug.Log("waypoint2 ���");
                    targetTransform.localRotation = Quaternion.Euler(0f, -90f, 0f);
                }
                else if (currentName.Equals("Waypoint3"))
                {
                    // Debug.Log("waypoint3 ���");
                    targetTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                }
                else if (currentName.Equals("Waypoint4"))
                {
                    // Debug.Log("waypoint4 ���");
                    targetTransform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                }
                else if (currentName.Equals("Waypoint5"))
                {
                    // Debug.Log("waypoint5 ���");
                    targetTransform.localRotation = Quaternion.Euler(0f, 180f, 0f);
                }
            }
        }
    }
}
