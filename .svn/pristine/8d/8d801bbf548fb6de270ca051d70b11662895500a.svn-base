using System.Reflection;
using UnityEngine;
using System.Collections;

public class FightState : BaseState
{
    public FightState(PlayerState state) : base(state) { }

    public override void CurrentAnimation()
    {
        playerState.Animator.SetInteger(AnimatorNum.AnimationState, AnimatorNum.FightAttack);
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
        if (AnimaStop())
        {
            playerState.SetPlayerState(playerState.StandingState);
        }
    }
}