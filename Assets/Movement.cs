using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;  // Speed of player movement

    private Rigidbody rb;     // Reference to the player's Rigidbody component

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Get input from player
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        // Apply movement to the player
        rb.velocity = movement * speed;
    }
}
