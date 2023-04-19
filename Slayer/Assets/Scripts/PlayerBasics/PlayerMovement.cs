using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;

    float horizontalInput;
    float verticalInput;

    public Transform orientation;
    Rigidbody rb;

    Vector3 moveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
