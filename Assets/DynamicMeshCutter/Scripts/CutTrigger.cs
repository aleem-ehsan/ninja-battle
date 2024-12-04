using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DynamicMeshCutter;
public class CutTrigger : MonoBehaviour
{
    [SerializeField] private PlaneBehaviour cutterPlane;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cutable"))
        {
            Debug.Log("Knife hit the trigger");
            cutterPlane.Cut();
        }
    }

}
