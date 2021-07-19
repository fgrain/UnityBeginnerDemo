using System.Reflection;
using UnityEngine;
using System.Collections;

public class OpenBoxState : BaseState
{
    public OpenBoxState(PlayerState state) : base(state) { }
    public override void CurrentAnimation()
    {
        if (!playerState.isFight)
        {
            playerState.Animator.SetInteger(AnimatorNum.AnimationState, AnimatorNum.IsOpenBox);
        }
        else
        {
            playerState.Animator.SetInteger(AnimatorNum.AnimationState, AnimatorNum.FightBoxOpen);
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
        if (AnimaStop())
        {
            playerState.isFight = true;
            PlayerMovement.Instance.gun.gameObject.SetActive(true);
            playerState.SetPlayerState(playerState.StandingState);
        }
    }
}