using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTileScript : MonoBehaviour
{
    Rigidbody targetRigidBody;
    Collider targetCollider;
    Animator targetAnimator;


    private void OnCollisionEnter(Collision collision)
    {
        GameObject targetObject = collision.gameObject;

        if (targetObject.tag.Equals("Monster")
            && !(targetObject.name.Equals("Body")))
        {
            // 포탈에서 튕겨나오는 표현을 위해 임시로 생성한 리지드 바디와 콜라이더 삭제
            targetRigidBody = targetObject.GetComponent<Rigidbody>();
            targetCollider = targetObject.GetComponent<Collider>();
            targetAnimator = targetObject.GetComponent<Animator>();

            Destroy(targetRigidBody);
            Destroy(targetCollider);

            targetAnimator.SetTrigger("DizzyTrigger");
        }
    }
}
