using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplayer;

    [Header("Ground Checking")]
    public LayerMask whatIsGround;
    public Transform orientation;

    [Header("Misc")]
    public float playerHeight;

    [Header("KeyBinds")]
    public KeyCode jumpkey = KeyCode.Space;

    bool isGrounded;
    bool readyToJump = true;

    float horizontal;
    float vertical;

    Vector3 dir;

    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        PlayerInput();
        CheckIsGrounded(isGrounded);
        SpeedControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        dir = orientation.forward * vertical + orientation.right * horizontal;

        rb.AddForce(dir.normalized * moveSpeed * 10f,ForceMode.Force);

        if(isGrounded)
        {
            rb.AddForce(dir.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if(!isGrounded)
        {
            rb.AddForce(dir.normalized * moveSpeed * 10f * airMultiplayer, ForceMode.Force);
        }
    }

    private void CheckIsGrounded(bool isGrounded)
    {
        if(isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void PlayerInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpkey) && readyToJump && isGrounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump),jumpCooldown);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatvel = new Vector3(rb.velocity.x,0f, rb.velocity.z);

        if(flatvel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatvel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x,rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}