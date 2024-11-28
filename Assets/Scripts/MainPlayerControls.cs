using UnityEngine;

public class MainPlayerControls : MonoBehaviour
{
    [Header("Player Settings")]
    public float shootForce = 10f;
    public float maxDragDistance = 5f;

    [Header("Arrow Settings")]
    public Transform pivotArrow; // Use CubePivot for both rotation and scaling

    private Rigidbody rb;
    private Vector2 startPosition;
    private Vector2 dragDirection;
    private bool isDragging = false;

    private float originalFixedDeltaTime;

    public bool isOnWall = false;
    public bool isGrounded = false; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalFixedDeltaTime = Time.fixedDeltaTime; // Save the original physics update rate
    }

    private void Update()
    {
        HandleTouchInput();
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    OnDragStart(touch.position);
                    break;

                case TouchPhase.Moved:
                    OnDragMove(touch.position);
                    break;

                case TouchPhase.Ended:
                    OnDragRelease();
                    break;
            }
        }
    }

    private void OnDragStart(Vector2 touchPosition)
    {
        if (isDragging) return;

        isDragging = true;
        startPosition = GetWorldPositionFromScreen(touchPosition);

        // Activate the CubePivot and reset scale
        if (pivotArrow != null)
        {
            pivotArrow.gameObject.SetActive(true);
            pivotArrow.localScale = new Vector3(pivotArrow.localScale.x, 0.1f, pivotArrow.localScale.z); // Reset Y scale
        }

        // Smooth slow-motion effect
        Time.timeScale = 0.1f;
        Time.fixedDeltaTime = originalFixedDeltaTime * Time.timeScale;
    }

    private void OnDragMove(Vector2 touchPosition)
    {
        if (!isDragging) return;

        Vector2 currentPosition = GetWorldPositionFromScreen(touchPosition);
        dragDirection = currentPosition - startPosition; // Calculate drag direction

        if (dragDirection.magnitude > maxDragDistance)
            dragDirection = dragDirection.normalized * maxDragDistance;

        // Update CubePivot rotation and scale
        if (pivotArrow != null)
        {
            // Rotate the CubePivot to point in the correct drag direction
            float angle = Mathf.Atan2(dragDirection.y, dragDirection.x) * Mathf.Rad2Deg;
            pivotArrow.rotation = Quaternion.Euler(0, 0, angle - 90); // Adjust for default orientation

            // Scale CubePivot based on drag distance, with 2x multiplier
            float scaleY = Mathf.Clamp(dragDirection.magnitude * 8, 0.1f, maxDragDistance * 8); // Ensure minimum scale is 0.1
            pivotArrow.localScale = new Vector3(pivotArrow.localScale.x, scaleY, pivotArrow.localScale.z);
        }
    }

    private void OnDragRelease()
    {
        if (!isDragging) return;

        isDragging = false;

        // Reset time scale to normal
        Time.timeScale = 1f;
        Time.fixedDeltaTime = originalFixedDeltaTime;

        // Deactivate the CubePivot
        if (pivotArrow != null)
        {
            pivotArrow.gameObject.SetActive(false);
        }

        // Apply force to the Rigidbody in the drag direction
        rb.velocity = dragDirection.normalized * shootForce;
    }

    private Vector2 GetWorldPositionFromScreen(Vector2 screenPosition)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, Camera.main.nearClipPlane));
        return new Vector2(worldPosition.x, worldPosition.y);
    }

    private void OnDrawGizmos()
    {
        // Visualize drag direction in the Scene view for debugging
        if (isDragging)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, (Vector2)transform.position + dragDirection);
        }
    }

    // Collision handling to stick to walls
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            // Stop player movement on collision with the wall
            rb.velocity = Vector2.zero;
            rb.useGravity = false;

            isOnWall = true;
        }
        if(collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            // Re-enable gravity when leaving the wall
            rb.useGravity = true;

            isOnWall = false;
        }
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }



    // private void OnCollisionStay(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("wall"))
    //     {
    //         // Keep the player stuck to the wall, prevent any movement
    //         rb.velocity = Vector2.zero;
    //     }
    // }
}
