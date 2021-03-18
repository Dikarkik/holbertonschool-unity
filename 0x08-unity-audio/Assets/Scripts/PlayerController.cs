using UnityEngine;

/// <summary>
/// Handle user input so the player can move left, right, forward, backward, and diagonally using the WASD keys.
/// The player jump when the Space button is pressed.
/// </summary>
public class PlayerController : MonoBehaviour
{
    // movement
    private CharacterController controller;
    private float playerSpeed = 7.5f;
    private Vector3 moveDirection;
    private Vector3 cameraForward = new Vector3(0,0,0);
    private Vector3 cameraRight = new Vector3(0, 0, 0);
    public Camera mainCam;

    // jump
    private Vector3 playerGravity;
    private float gravityValue = -12.81f;
    private float jumpHeight = 1.0f;

    // model
    public Transform model;
    
    // animations
    public Animator anim;
    private string runningAnim = "running";
    private string playIdleAnim = "playIdle";
    
    void Start() => controller = GetComponent<CharacterController>();

	void Update()
    {
        // movement
        cameraForward = mainCam.transform.forward;
        cameraRight = mainCam.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;

        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("cantMove"))
            moveDirection = Vector3.Normalize((Input.GetAxis("Vertical") * cameraForward) + (Input.GetAxis("Horizontal") * cameraRight));

        //model rotation
        if (moveDirection != Vector3.zero)
            model.rotation = Quaternion.LookRotation(moveDirection);

        if (Input.GetAxis("Vertical") != 0 ||
            Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool(runningAnim, true);
        }
        else
            anim.SetBool(runningAnim, false);
        
        // jump
        if (controller.isGrounded && !anim.GetBool(playIdleAnim))
        {
            anim.SetBool(playIdleAnim, true);
        }
        else if(!controller.isGrounded)
        {
            playerGravity.y += gravityValue * Time.deltaTime;
        }
        else if(Input.GetButtonDown("Jump"))
	    {
            playerGravity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            anim.SetBool(playIdleAnim, false);
            anim.SetTrigger("jumpTrigger");
        }

        // movement (Unexpected behavior if place this line below 'jump' line)
        controller.Move(moveDirection * playerSpeed * Time.deltaTime);
		// jump
		controller.Move(playerGravity * Time.deltaTime);

        // fall
        if(transform.position.y < -20)
        {
            moveDirection.x = 0;
            moveDirection.z = 0;
            transform.position = new Vector3(0, 30, 0);
            playerGravity.y = gravityValue;
        }
    }

    public void FallingAnim()
    {
        anim.SetBool(playIdleAnim, false);
        anim.SetTrigger("falling");
    }
}
