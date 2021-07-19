using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Hurted))]
public class Enemy : MonoBehaviour
{
    private Vector3 m_initPos;

    // Start is called before the first frame update
    void Start()
    {
        m_initPos = transform.position;
    }

    public void Revival(float reBlood,float noAttTime)
    {
        if (GetComponent<Hurted>())
        {
            Hurted hurted = GetComponent<Hurted>();
            hurted.blood = reBlood;
            hurted.IsLiving  = true;
            transform.position = m_initPos;
            StartCoroutine(StartTime(noAttTime));
        }

    }

    IEnumerator StartTime(float noAttTime)
    {
        yield return new WaitForSeconds(noAttTime);
        GetComponent<CapsuleCollider>().enabled = true;
    }
}