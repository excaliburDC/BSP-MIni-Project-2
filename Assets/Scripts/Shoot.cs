using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed = 70f;
    private Transform target;

    

    private void Update()
    {
        AttackTarget();
    }

    public void FindTarget(Transform m_target)
    {
        target = m_target;
    }

    void AttackTarget()
    {
        if (target == null)
        {
            gameObject.SetActive(false);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            Debug.Log("Target Hit");
            gameObject.SetActive(false);
            //HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitEffect()
    {

    }

}
