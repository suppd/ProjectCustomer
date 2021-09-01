using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]

    Vector3 movementDirection;

    public float moveSpeed = 6f;
    public float movementMultiplier = 5f;

    float rbDrag = 6f;

    float horizontalMovement;
    float verticalMovement;

    public Rigidbody rb;
    
    private void Start()
    {
        rb.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        CharInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void controlDrag()
    {
        rb.drag = rbDrag;
    }
    void CharInput()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        movementDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;

    }

    void MovePlayer()
    {
        rb.AddForce(movementDirection * moveSpeed *movementMultiplier, ForceMode.Acceleration);
    }
}
