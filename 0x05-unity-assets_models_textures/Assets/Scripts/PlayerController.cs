using UnityEngine;

/// <summary>
/// Handle user input so the player can move left, right, forward, backward, and diagonally using the WASD keys.
/// The player jump when the Space button is pressed.
/// </summary>
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    // movement
    private Vector3 moveDirection;
    private float playerSpeed = 8f;

    // jump
    private Vector3 playerGravity;
    private float gravityValue = -9.81f;
    private float jumpHeight = 1.0f;

	void Start() => controller = GetComponent<CharacterController>();

	void Update()
    {
        // movement
        moveDirection = Vector3.Normalize((Input.GetAxis("Vertical") * Camera.main.transform.forward) +
                                          (Input.GetAxis("Horizontal") * Camera.main.transform.right));

        // jump
        if(!controller.isGrounded)
        {
            playerGravity.y += gravityValue * Time.deltaTime;
        }
        else if(Input.GetButtonDown("Jump"))
	    {
            playerGravity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
		}

        // movement (Unexpected behavior if place this line below 'jump' line)
        controller.Move(moveDirection * Time.deltaTime * playerSpeed);
		// jump
		controller.Move(playerGravity * Time.deltaTime);

        // fall
        if(transform.position.y < -20)
        {
            transform.position = new Vector3(0, 30, 0);
            playerGravity.y = gravityValue;
        }
    }
}
