using System.Reflection;
using UnityEngine;
using System.Collections;

public class DieState : BaseState
{
    public DieState(PlayerState state) : base(state) { }

    public override void CurrentAnimation()
    {
        if (!playerState.isFight)
        {
            playerState.Animator.SetInteger(AnimatorNum.AnimationState, AnimatorNum.IsDie);
        }
        else{
            playerState.Animator.SetInteger(AnimatorNum.AnimationState, AnimatorNum.FightDie);
        }

    }

    public override void CurrentAudio()
    {
        playerState.AudioSource.Stop();
        GameEnding.Instance.CaughtPlayer();
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

    }
}