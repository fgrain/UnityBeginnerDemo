using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Arm
{
    public LineRenderer trail;
    public float shootTime = 1;
    public bool canShoot=true;
    Vector3 m_target;
    Vector3 m_origin;
    Transform m_TargetTrans;
    float m_speed;
    public Vector3 Target { get => m_target; }
    public void MouseClickPos()
    {
        m_origin = transform.position;
        //Ray ray = new Ray(transform.position, PlayerMovement.Instance.DesiredForward);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            PlayerMovement.Instance.transform.LookAt(new Vector3(hit.point.x ,PlayerMovement.Instance.transform.position.y , hit.point.z));
            //m_target = new Vector3(hit.point.x ,transform.position.y , hit.point.z);
            m_target=hit.point;
            m_TargetTrans=hit.transform;
            m_speed = hit.distance / shootTime;
        }
    }

    public void Shoot()
    {
        trail.gameObject.SetActive(true);
        CheckTarget(m_TargetTrans);
        StartCoroutine(ShootControll());
        canShoot=false;
    }

    IEnumerator ShootControll()
    {
        while (m_origin != m_target)
        {
            Vector3[] pos = { m_origin, m_target };
            trail.SetPositions(pos);
            //Debug.Log("shoot" + m_origin + ":" + m_target);
            m_origin = Vector3.MoveTowards(m_origin, m_target, m_speed * Time.deltaTime);
            yield return null;
        }
        canShoot=true;
        trail.gameObject.SetActive(false);
    }
}
