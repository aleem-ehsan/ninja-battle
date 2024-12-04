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

    public bool isDead = false;


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
        // TODO:   Enemy dead check
        // if(! _enemy.IsDead ){
            animator.SetBool("Attack", range.isInRange);
        //     Debug.Log("Enemy is not Dead");
        // }else{
        //     range.gameObject.SetActive(false);
        //     // GameManager.instance.EnemyKilled();
        //     // disable this script
        //     this.gameObject.GetComponent<Enemy>().enabled = false;
        //     Debug.Log("Enemy is Dead");
        // }
    }

    public void ShootBlade(){
        Debug.Log("Shoot Blade");
       GameObject blade = Instantiate(bladePrefab, handPos.position, Quaternion.identity); // instantiate blade

        blade.GetComponent<Blade>().targetTransform = playerTransform; // set the target transform of the blade to the player transform

    }
    


    public void EnemyDie(){
        Debug.Log("Enemy Die");
        isDead = true;
    }

}
