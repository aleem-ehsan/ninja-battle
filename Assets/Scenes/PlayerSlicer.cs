using DynamicMeshCutter;
using UnityEngine;

public class PlayerSlicer : MonoBehaviour
{
    private DynamicMeshCutter.PlaneBehaviour planeCutter;

    void Start()
    {
        // Find the PlaneBehaviour attached to the player
        planeCutter = GetComponentInChildren<DynamicMeshCutter.PlaneBehaviour>();

        if (planeCutter == null)
        {
            Debug.LogError("PlaneBehaviour script not found on player!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Ensure the collided object has a MeshTarget component
        if (collision.gameObject.GetComponent<MeshTarget>() != null)
        {
            Debug.Log("Collided!");
            // Trigger the slicing logic
            // planeCutter.Cut();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Alternative: Use trigger-based detection
        if (other.GetComponent<DynamicMeshCutter.MeshTarget>() != null)
        {
            Debug.Log("Triggered!");
            // planeCutter.Cut();
        }
    }
}
