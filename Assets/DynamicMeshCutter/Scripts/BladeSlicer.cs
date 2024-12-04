using UnityEngine;
using DynamicMeshCutter;

public class BladeSlicer : MonoBehaviour
{
    private CutterBehaviour cutter;

    private void Start()
    {
        // Find the CutterBehaviour in the scene or attach it to the blade
        cutter = FindObjectOfType<CutterBehaviour>();
        if (cutter == null)
        {
            Debug.LogError("CutterBehaviour not found in the scene.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("sliceable"))
        {

        // Check if the collided object has a MeshTarget component
        MeshTarget meshTarget = other.GetComponent<MeshTarget>();
        if (meshTarget != null)
        {
            // Define the cutting plane based on the blade's position and orientation
            Vector3 planeNormal = transform.up; // Assuming the blade's up direction is the normal
            Vector3 planePosition = transform.position;

            // Perform the cut
             // Perform the cut
            // cutter.Cut(
            //     meshTarget,                     // The MeshTarget to cut
            //     planePosition,                  // Position of the cutting plane
            //     planeNormal,                    // Normal of the cutting plane
            //     OnCutComplete,                  // Callback for when the cut is completed
            //     OnPieceCreated,                 // Callback for when a piece is created
            //     null                            // Pass any additional data, if needed
            // );
        }
        }

    }
// DynamicMeshCutter.Info info, DynamicMeshCutter.MeshCreationData creationData
    private void OnCutComplete(GameObject original, GameObject[] results, object data)
{
    Debug.Log($"Cut complete! Original: {original.name}");
    Debug.Log($"Number of resulting pieces: {results.Length}");
    foreach (var result in results)
    {
        Debug.Log($"Resulting piece: {result.name}");
    }
}

    private void OnPieceCreated(MeshTarget piece)
    {
        Debug.Log("Piece created: " + piece.name);
        // Handle logic for newly created pieces, such as applying physics or effects
    }
}
