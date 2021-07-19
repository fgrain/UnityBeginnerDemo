using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    BaseState nowState;
    Animator m_Animator;
    AudioSource m_AudioSource;
    public BaseState StandingState;
    public BaseState WalkingState;
    public BaseState DieState;
    public BaseState TouchSwitch;
    public BaseState HurtState;
    public BaseState OpenBoxState;
    public BaseState FightState;
    public bool isFight;

    public PlayerState(Animator animator, AudioSource audioSource)
    {
        Animator = animator;
        AudioSource = audioSource;
        StandingState = new StandingState(this);
        WalkingState = new WalkingState(this);
        DieState = new DieState(this);
        TouchSwitch = new TouchSwitch(this);
        HurtState = new HurtState(this);
        OpenBoxState=new OpenBoxState(this);
        FightState=new FightState(this);
        isFight = false;
    }
    public Animator Animator { get => m_Animator; set => m_Animator = value; }
    public AudioSource AudioSource { get => m_AudioSource; set => m_AudioSource = value; }
    public void SetPlayerState(BaseState newstate)
    {
        nowState = newstate;
        nowState.CurrentState();
    }

    public BaseState GetNowState()
    {
        return nowState;
    }

    public void Update()
    {
        if (!PlayerMovement.Instance.Huted.IsLiving)
        {
            SetPlayerState(DieState);
        }
        nowState.HandleInput();
    }
}