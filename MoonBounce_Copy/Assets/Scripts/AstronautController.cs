using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautController : MonoBehaviour
{

    public CharacterController2D controller;
    //public Animator animator;

    public float runSpeed = 25f;
    public bool hasJumpPotion = false;
    public bool hasSpeedPotion = false;
    public int potionModAmount = 0;

    public AudioClip jumpClip;
    public AudioClip potionJumpClip;
    public AudioClip landClip;

    private float runTimer = 0f;
    public float runMax = 1f;
    public float runDir = 0.01f;

    private float potionTimeMax = 5f;
    private float potionTimeCur = 0f;

    float horizontalmove = 0f;
    bool jumpFlag = false;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        horizontalmove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //animator.SetFloat("Speed", Mathf.Abs(horizontalmove));

        if (jumpFlag)
        {
            jumpFlag = false;
            //animator.SetBool("IsJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            /*if (animator.GetBool("IsJumping") == false)
            {
                if (hasJumpPotion == false)
                {
                    AudioSource.PlayClipAtPoint(jumpClip, transform.position);
                }
                else
                {
                    AudioSource.PlayClipAtPoint(potionJumpClip, transform.position);
                }

                jump = true;
                animator.SetBool("IsJumping", true);
            }*/
            jump = true;
            //animator.SetBool("IsJumping", true);
        }
      }

    public void OnLanding()
    {
        jump = false;
        jumpFlag = true;
        //animator.SetBool("IsJumping", false);
        //AudioSource.PlayClipAtPoint(landClip, transform.position);
    }

    void FixedUpdate()
    {
        controller.m_JumpForceMod = 0;

        controller.Move(horizontalmove * Time.fixedDeltaTime, false, jump);

        if (jump)
        {
            jumpFlag = false;
        }
    }

  }
