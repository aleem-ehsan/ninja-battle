using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody rb;

    public Transform targetTransform;

    [SerializeField] private float speed = 10f;

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
        Destroy(gameObject);

    }
    
}
