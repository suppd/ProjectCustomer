using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]

    Vector3 movementDirection;

    float horizontalMovement;
    float verticalMovement;

    public Rigidbody rb;
    
    private void Start()
    {
        rb.GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        CharInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void CharInput()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        movementDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;

    }

    void MovePlayer()
    {
        rb.AddForce(movementDirection);
    }
}
