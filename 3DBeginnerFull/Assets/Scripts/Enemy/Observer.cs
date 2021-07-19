using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : Arm
{
    private Transform m_player;
    private PlayerMovement m_playerMovement;
    private GameEnding m_gameEnding;
    private Transform m_HurtTarget;

    private void Start()
    {
        m_player = GameObject.Find("JohnLemon").transform;
        m_playerMovement = m_player.GetComponent<PlayerMovement>();
        m_gameEnding = GameObject.Find("GameEnding").GetComponent<GameEnding>();
    }

    private void Update()
    {
        if (IsInRange)
        {
            //Debug.Log("Hurt");
            ContinueHurt(m_HurtTarget, timeHurted);
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tag.Player)
        {
            if (other.GetComponent<Hurted>())
            {
                Hurted hurted=other.GetComponent<Hurted>();
                //Debug.Log(other.tag);
                IsInRange = true;
                hurted.IsInAttactRange = true;
                m_HurtTarget = other.transform;
                if(transform.tag==Tag.Enemy){
                    hurted.IsEnemyHurt=true;
                }
                else if(transform.tag==Tag.Trap){
                    hurted.IsTrapHurt=true;
                }
                //ContinueHurt(other.transform, timeHurted);
            }
        }

    }

}
