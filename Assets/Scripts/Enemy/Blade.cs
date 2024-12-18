using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody rb;

    public Transform targetTransform;

    [SerializeField] private float speed = 10f;

    [SerializeField] private Animation animation;

    [SerializeField] private Collider collider;



    void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = (targetTransform.position - transform.position).normalized * speed; // 10 is the speed of the blade
        // Vector3 direction = (playerTransform.position - transform.position).normalized;
        //     float speed = 10f; // Set the speed of the blade
        //     rb.velocity = direction * speed;
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("wall")  || other.CompareTag("ground") ){
            StopBlade();
        }
        // else if(other.CompareTag("Player")){
        //     Debug.Log("Do Nothing with blade");
        //     MainPlayerControls mainPlayerControls = other.GetComponent<MainPlayerControls>();
        //     if(mainPlayerControls.IsInAir){
        //         Debug.Log("Slice the Blade");
        //     }
        // }
        else if(other.CompareTag("knife") ){
                Debug.Log("Blade collided with knife");
        }else if(other.CompareTag("Player") ){
                Debug.Log("Player collided with Player");
        }else{

            Debug.Log("Blade collided with " + other.name);
            Destroy(gameObject);

        }

    }

    private void StopBlade(){
        // make it static
            // rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            animation.Stop();

            // ignore collision with player
            Physics.IgnoreCollision(collider, targetTransform.GetComponent<Collider>(), true);


            Destroy(gameObject , 5f);
    }
    
}
