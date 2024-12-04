using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsHandler : MonoBehaviour
{

  

    private Animator animator;

    [SerializeField] private MainPlayerControls mainPlayerControls; 
    [SerializeField] private Transform player_Transform; 



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

    

        if(mainPlayerControls.isOnWall){

                animator.SetBool("isOnWall", true);
            if (player_Transform.position.x > 0)  // wall Right
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else // wall Left
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }else{
            animator.SetBool("isOnWall", false);
             // not on wall so reset rotation
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }


    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            animator.SetBool("isDead", true);
        }
    }


  


}
