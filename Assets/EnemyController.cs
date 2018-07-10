using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {



    [SerializeField]
    private int hp = 3;
    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
            if (hp<=0)
            {
                StartCoroutine(StopDestroy());
            }
        }
    }

    private bool playerAround = false;
    private float range = 2f;
    private Transform player;


    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool e_Grounded;            // Whether or not the player is grounded.
    const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character



    private Transform e_GroundCheck;    // A position marking where to check if the player is grounded.
    private Transform e_swordCheck;
    [SerializeField]
    private Animator e_Anim;

    private Animator e_AnimSword;

    private IEnumerator StopDestroy()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        Destroy(gameObject);
    }

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        //e_swordCheck = transform.Find("SwordCheck");
        e_GroundCheck = transform.Find("GroundCheck");
        //e_AnimSword = e_swordCheck.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate () {

        


        e_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(e_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                e_Grounded = true;
            
        }
        e_Anim.SetBool("Ground", e_Grounded);



        //// If crouching, swing a sword
        if (Vector3.Distance(player.position, transform.position) <= range)
        {
            playerAround = true;
            //e_swordCheck.gameObject.SetActive(true);
            //e_AnimSword.SetBool("Swinging", true);
            e_Anim.SetBool("Crouch", true);
        }
        else
        {
            playerAround = false;
            //e_swordCheck.gameObject.SetActive(false);
            //e_AnimSword.SetBool("Swinging", false);
            e_Anim.SetBool("Crouch", false);
        }

    }




}
