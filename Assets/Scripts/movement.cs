using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;        // Movement speed
    public float jumpForce = 10f;       // Jump force
    public float gravity = -9.81f;      // Gravity force
    public Transform groundCheck;       // Ground check transform
    public float groundDistance = 0.4f; // Distance to the ground
    public LayerMask groundMask;        // Ground layer mask
    public Rigidbody rb;                // Reference to the Rigidbody component

    private bool isGrounded;            // Check if player is on the ground

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get horizontal and vertical input
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Calculate movement direction
        Vector3 moveDirection = transform.right * moveHorizontal + transform.forward * moveVertical;

        // Move player horizontally
        rb.MovePosition(rb.position + moveDirection.normalized * moveSpeed * Time.fixedDeltaTime);

        // Check if player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            // Jump when player presses Space key and is on the ground
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpForce * -2f * gravity), ForceMode.Impulse);
        }

        // Apply gravity to the player
        rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);
    }
}
