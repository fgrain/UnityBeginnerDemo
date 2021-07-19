using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    private float timeing;
    protected PlayerState playerState;
    public BaseState(PlayerState state)
    {
        playerState = state;
    }
    public void CurrentState()
    {
        CurrentAnimation();
        CurrentAudio();
    }
    public abstract void CurrentAudio();
    public abstract void CurrentAnimation();
    public abstract string GetStateName();
    public abstract void Update();
    public abstract void HandleInput();

    //检测当前动作是否结束
    public bool AnimaStop()
    {
        AnimatorStateInfo animatorInfo;
        animatorInfo = playerState.Animator.GetCurrentAnimatorStateInfo(0);
        if ((animatorInfo.normalizedTime > 1.0f))
        {
            return true;
        }
        else return false;
    }

    //切换攻击状态
    public void ChangeToAttack()
    {
        if (PlayerMovement.Instance.PrepShoot)
        {
            Gun gun = PlayerMovement.Instance.gun;
            if (gun.canShoot)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    playerState.SetPlayerState(playerState.FightState);
                    gun.MouseClickPos();
                    gun.Shoot();
                }
            }

        }
    }
}


