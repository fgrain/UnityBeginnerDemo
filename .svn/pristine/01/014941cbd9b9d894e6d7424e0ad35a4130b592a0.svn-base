using System.Reflection;
using UnityEngine;
using System.Collections;

public class TouchSwitch : BaseState
{
    public TouchSwitch(PlayerState state) : base(state) { }
    public override void CurrentAnimation()
    {
        if (!playerState.isFight)
        {
            playerState.Animator.SetInteger(AnimatorNum.AnimationState, AnimatorNum.IsSwitch);
        }
        else
        {
            playerState.Animator.SetInteger(AnimatorNum.AnimationState, AnimatorNum.FightSwitch);
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