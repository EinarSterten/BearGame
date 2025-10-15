using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private InputAction _moveAction, _jumpAction;
    private CharacterController _characterController;

    private Vector2 moveInput;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 1000f;
    [SerializeField] float verticalVelocity;
    [SerializeField] float gravity = -9.81f;

    //Animator
    [SerializeField] Animator animator;


    private void Awake()
    {

        _characterController = GetComponent<CharacterController>();
    }

    //private void OnEnable()
    //{
    //    _moveAction.Enable();
    //    _jumpAction.Enable();
    //}

    //private void OnDisable()
    //{
    //    _moveAction.Disable();
    //    _jumpAction.Disable();
    //}

    public void OnInteractAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Interaction triggered");
            animator.SetTrigger("interact");
        }
    }

    public void OnMoveAction(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJumpAction(InputAction.CallbackContext context)
    {
        if (context.performed && _characterController.isGrounded)
        {
            Debug.Log("Jump initiated");
            Jump();
        }
    }

    private void Jump()
    {
        verticalVelocity = jumpForce;
    }

    private void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed;

        // Apply gravity
        if (_characterController.isGrounded)
        {
            if (verticalVelocity < 0)
                verticalVelocity = 0f;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        move.y = verticalVelocity;

        _characterController.Move(move * Time.deltaTime);

        // Determine if player is moving
        bool isMoving = moveInput.magnitude > 0.1f; // threshold to avoid slight input noise

        // Set animator parameter
        animator.SetBool("isMoving", isMoving);
    }
}