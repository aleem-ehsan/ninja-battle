using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeMeshSeparater : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("knife"))
        {

            transform.parent = null;
            rb.useGravity = true;
            rb.isKinematic = false;

            while (transform.parent != null)
            {
                transform.parent = null;
            }
            while (rb.useGravity == false)
            {
                rb.useGravity = true;
            }
            while (rb.isKinematic == true)
            {
                rb.isKinematic = false;
            }

        // now add force in the direction of the knife
        rb.velocity = (other.transform.position - transform.position).normalized * 3; // 10 is the speed of the blade

            // set its parent to null
        }


    }

}


