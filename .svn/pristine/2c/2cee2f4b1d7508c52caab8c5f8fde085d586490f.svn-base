using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Hurted))]
public class PlayerMovement : MonoSingleton<PlayerMovement>
{
    public float turnSpeed = 20f;
    public Gun gun;
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Vector3 m_desiredForward;
    Quaternion m_Rotation = Quaternion.identity;
    PlayerState playerState;
    GameObject m_currentLight;
    GameObject m_currentBox;
    bool m_isTouchSwitch;
    bool m_isTouchBox = false;
    bool m_isWalking;
    string m_nowState;
    bool prepShoot = false;
    Hurted m_huted;
    float m_normalSpeed = 1;

    public bool IsWalking { get => m_isWalking; }
    public Hurted Huted { get => m_huted; set => m_huted = value; }
    public bool PrepShoot { get => prepShoot; set => prepShoot = value; }
    public Vector3 DesiredForward { get => m_desiredForward; }

    void Start()
    {
        m_huted = GetComponent<Hurted>();
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
        playerState = new PlayerState(m_Animator, m_AudioSource);
        playerState.SetPlayerState(playerState.StandingState);
    }

    private void Update()
    {
        //Debug.Log(playerState.GetNowState().GetStateName());
        playerState.Update();
        GetState();

        if (playerState.isFight)
        {
            if (Input.GetMouseButtonDown(1))
            {
                prepShoot = true;
                UIController.Instance.CursorDown();
            }
            else if (Input.GetMouseButtonUp(1))
            {
                prepShoot = false;
                UIController.Instance.CursorUp();
            }
        }
    }

    void FixedUpdate()
    {
        if (m_isTouchSwitch)
        {
            ChangeLight();
        }
        else if (m_isTouchBox)
        {
            OpenBox();
        }
        if (m_huted.IsLiving)
        {
            PlayerMove();
        }
    }

    void GetState()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        m_isWalking = hasHorizontalInput || hasVerticalInput;

    }
    void PlayerMove()
    {
        if (m_huted.IsSlowDown)
        {
            m_normalSpeed = 0.5f;
        }
        else
        {
            m_normalSpeed = 1;
        }
        m_desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(m_desiredForward);
    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude * m_normalSpeed);
        m_Rigidbody.MoveRotation(m_Rotation);
    }

    public void Caughted()
    {
        StartCoroutine("Injured");
    }

    public void Escape()
    {
        StopCoroutine("Injured");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tag.Switch)
        {
            m_isTouchSwitch = true;
            m_currentLight = other.transform.parent.gameObject;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tag.Switch)
        {
            m_isTouchSwitch = false;
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == Tag.Box)
        {
            m_isTouchBox = true;
            m_currentBox = other.gameObject;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.tag == Tag.Box)
        {
            m_currentBox.GetComponent<Animator>().SetInteger(AnimatorNum.BoxAnima, AnimatorNum.BoxOpenLoop);
            m_isTouchBox = false;
        }
    }

    public void ChangeLight()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("F");
            playerState.SetPlayerState(playerState.TouchSwitch);
            LightControll lightControll = m_currentLight.GetComponent<LightControll>();
            LightManager.Instance.ControllSwitch(m_currentLight, !lightControll.IsOpen);
            lightControll.ResetLight();
            //Debug.Log(m_currentLight.GetComponent<LightControll>().IsOpen);
        }
    }

    public void OpenBox()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("F");
            playerState.SetPlayerState(playerState.OpenBoxState);
            m_currentBox.GetComponent<Animator>().SetInteger(AnimatorNum.BoxAnima, AnimatorNum.BoxOpen);
            m_currentBox.GetComponent<Collider>().enabled = false;
        }
    }

}