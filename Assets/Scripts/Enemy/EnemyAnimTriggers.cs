using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BzKovSoft.CharacterSlicer.Samples
{
public class EnemyAnimTriggers : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShootBladeNow(){
        enemy.ShootBlade();
    }
}
}