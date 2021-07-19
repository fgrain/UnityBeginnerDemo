using System.Reflection;
using UnityEngine;
using System.Collections;

public class WalkingState : BaseState
{
    public WalkingState(PlayerState state) : base(state) { }

    public override void CurrentAnimation()
    {
        if (!playerState.isFight)
        {
            playerState.Animator.SetInteger(AnimatorNum.AnimationState, AnimatorNum.IsWalking);
        }
        else
        {
            playerState.Animator.SetInteger(AnimatorNum.AnimationState, AnimatorNum.FightWalking);
        }
    }

    public override void CurrentAudio()
    {
        playerState.AudioSource.Play();
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
        ChangeToAttack();
        if (PlayerMovement.Instance.Huted.IsInAttactRange)
        {
            playerState.SetPlayerState(playerState.HurtState);
        }
        else if (!PlayerMovement.Instance.IsWalking)
        {
            playerState.SetPlayerState(playerState.StandingState);
        }
        
    }
}