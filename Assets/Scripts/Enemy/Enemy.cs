using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Range range;

    [SerializeField] private GameObject bladePrefab;
    [SerializeField] private Transform handPos;

    [SerializeField] private Transform playerTransform;


    void Awake(){
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Attack", range.isInRange);
    }

    public void ShootBlade(){
        Debug.Log("Shoot Blade");
       GameObject blade = Instantiate(bladePrefab, handPos.position, Quaternion.identity); // instantiate blade

        blade.GetComponent<Blade>().targetTransform = playerTransform; // set the target transform of the blade to the player transform

    }

}
