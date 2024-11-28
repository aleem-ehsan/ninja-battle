using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsHandler : MonoBehaviour
{

  

    private Animator animator;

    [SerializeField] private MainPlayerControls mainPlayerControls; 


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(isGrounded)
        // {
        //     animator.SetBool("isGrounded", false);
        // }
        // else
        // {
        //     animator.SetBool("isJumping", true);
        // }

        animator.SetBool("isGrounded", mainPlayerControls.isGrounded);
        animator.SetBool("isOnWall", mainPlayerControls.isOnWall);

    }


  


}
