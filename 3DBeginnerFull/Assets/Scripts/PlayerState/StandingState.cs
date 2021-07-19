using System.Reflection;
using UnityEngine;
using System.Collections;

public class StandingState : BaseState
{
    public StandingState(PlayerState state) : base(state)
    {

    }
    public override void CurrentAnimation()
    {
        if (!playerState.isFight)
        {
            playerState.Animator.SetInteger(AnimatorNum.AnimationState, AnimatorNum.IsIdle);
        }
        else
        {
            playerState.Animator.SetInteger(AnimatorNum.AnimationState, AnimatorNum.FightIdle);
        }
        
    }

    public override void CurrentAudio()
    {
        playerState.AudioSource.Stop();
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
        if (PlayerMovement.Instance.IsWalking)
        {
            playerState.SetPlayerState(playerState.WalkingState);
        }
        
    }
}