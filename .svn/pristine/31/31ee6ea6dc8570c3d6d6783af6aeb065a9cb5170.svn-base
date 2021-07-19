using System.Reflection;
using UnityEngine;
using System.Collections;

public class HurtState : BaseState
{
    public HurtState(PlayerState state) : base(state) { }

    public override void CurrentAnimation()
    {
        if (!playerState.isFight)
        {
            if (PlayerMovement.Instance.Huted.IsEnemyHurt)
            {
                playerState.Animator.SetInteger(AnimatorNum.AnimationState, AnimatorNum.IsHitEnemy);
            }
            else if (PlayerMovement.Instance.Huted.IsTrapHurt)
            {
                playerState.Animator.SetInteger(AnimatorNum.AnimationState, AnimatorNum.IsHitTrap);
            }
        }
        else
        {
            if (PlayerMovement.Instance.Huted.IsEnemyHurt)
            {
                playerState.Animator.SetInteger(AnimatorNum.AnimationState, AnimatorNum.FightHitEnemy);
            }
            else if (PlayerMovement.Instance.Huted.IsTrapHurt)
            {
                playerState.Animator.SetInteger(AnimatorNum.AnimationState, AnimatorNum.FightHitTrap);
            }
        }


    }

    public override void CurrentAudio()
    {

    }

    public override string GetStateName()
    {
        MethodBase method = new System.Diagnostics.StackTrace().GetFrame(0).GetMethod();
        string className = method.ReflectedType.FullName;
        return className;
    }
    public override void Update()
    {

    }
    public override void HandleInput()
    {
        if (PlayerMovement.Instance.IsWalking)
        {
            playerState.SetPlayerState(playerState.WalkingState);
        }
        else if (AnimaStop())
        {
            playerState.SetPlayerState(playerState.StandingState);
        }

    }
}