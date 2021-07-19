using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControll : Arm
{
    private bool isOpen = true;
    public bool IsOpen { get => isOpen; set => isOpen = value; }

    public float TimeEnemyRevival = 3;
    public float TimeLightClose = 15;
    public float TiemLightOpen = 10;
    private void Update()
    {
        ChangeLightState();
    }

    public void ChangeLightState()
    {

        if (PlayerMovement.Instance.Huted.IsLiving)
        {
            if (!isOpen)
            {
                //Debug.Log("OpenTime:" + m_TimeControll);
                LightManager.Instance.ControllSwitch(gameObject, true);
                if (TimeControll < TiemLightOpen)
                {
                    TimeControll += Time.deltaTime;
                }
                else
                {
                    isOpen = true;
                    TimeControll = 0;
                }
            }
            else
            {
                //Debug.Log("CloseTime:" + m_TimeControll);
                LightManager.Instance.ControllSwitch(gameObject, false);
                if (TimeControll < TimeEnemyRevival)
                {
                    //怪物复活时间
                    TimeControll += Time.deltaTime;
                }
                else if (TimeControll > TimeEnemyRevival && TimeControll < TimeEnemyRevival + 0.1f)
                {
                    TimeControll += Time.deltaTime;
                    foreach (var enemy in LightManager.Instance.enemies.Values)
                    {
                        if (!enemy.IsLiving)
                        {
                            enemy.gameObject.SetActive(true);
                            enemy.GetComponent<Enemy>().Revival(enemy.initBlood,TimeEnemyRevival);
                        }
                    }
                }
                else if (TimeControll < TimeLightClose)
                {
                    TimeControll += Time.deltaTime;
                }
                else
                {
                    TimeControll = 0;
                    isOpen = false;
                }
            }
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tag.Enemy)
        {
            //base.OnTriggerEnter(other);
            if (other.gameObject.GetComponent<Hurted>())
            {
                Hurted enemyState = other.gameObject.GetComponent<Hurted>();
                enemyState.Attacked(attackNum);
                //Debug.Log(other + ":" + enemyState.IsLiving);
                if (!enemyState.IsLiving)
                {
                    other.gameObject.SetActive(false);
                    LightManager.Instance.enemies[other.name] = enemyState;
                }
            }
        }

    }
    public void ResetLight()
    {
        TimeControll = 0;
        isOpen = !isOpen;
    }
}
