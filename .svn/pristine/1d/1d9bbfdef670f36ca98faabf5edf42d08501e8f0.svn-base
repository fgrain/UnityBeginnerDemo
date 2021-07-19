using System;
using UnityEngine;
public class Arm : MonoBehaviour
{
    public float attackNum = 1;//攻击力
    public float attackRange = 0;//攻击范围
    public float timeHurted = 1;
    private float m_TimeControll = 0;
    private bool m_isInRange;

    public bool IsInRange { get => m_isInRange; set => m_isInRange = value; }
    public float TimeControll { get => m_TimeControll; set => m_TimeControll = value; }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Hurted>())
        {
            m_isInRange = true;
            other.GetComponent<Hurted>().IsInAttactRange = true;
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Hurted>())
        {
            m_isInRange = false;
            Hurted hurted = other.GetComponent<Hurted>();
            hurted.IsInAttactRange = false;
            if (transform.tag == Tag.Enemy)
            {
                hurted.IsEnemyHurt = false;
            }
            else if (transform.tag == Tag.Trap)
            {
                hurted.IsTrapHurt = false;
            }
        }
    }

    //检查目标物是否可攻击，是则攻击一次
    public void CheckTarget(Transform target)
    {
        Vector3 direction = target.position - transform.position + Vector3.up;
        Ray ray = new Ray(transform.position, direction);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit))
        {
            if (raycastHit.collider.GetComponent<Hurted>())
            {
                Hurted enemyState = target.GetComponent<Hurted>();
                Debug.Log(enemyState.blood);
                enemyState.Attacked(attackNum);
                if (!enemyState.IsLiving)
                {
                    if (enemyState.tag == Tag.Enemy)
                    {
                        target.gameObject.SetActive(false);
                        LightManager.Instance.enemies[target.name] = enemyState;
                    }
                }
            }
        }
    }

    //持续攻击目标无，timeInterval为攻击cd
    public void ContinueHurt(Transform trans, float timeInterval)
    {
        if (trans.GetComponent<Hurted>())
        {
            if (trans.GetComponent<Hurted>().IsInAttactRange)
            {
                if (m_TimeControll == 0)
                {
                    m_TimeControll += Time.deltaTime;
                    CheckTarget(trans);
                    if (trans.tag == Tag.Player)
                    {
                        UIController.Instance.UpdateBlood();
                    }
                }
                else if (m_TimeControll < timeInterval)
                {
                    m_TimeControll += Time.deltaTime;
                }
                else
                {
                    m_TimeControll = 0;
                }
            }
        }

    }
}