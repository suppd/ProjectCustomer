using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]

    Vector3 movementDirection;

    public float moveSpeed = 6f;
    public float movementMultiplier = 5f;
    public AudioSource footSteps;

    float rbDrag = 6f;
    float horizontalMovement;
    float verticalMovement;
    bool isWalking;

    public Rigidbody rb;
    
    private void Start()
    {
        rb.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        isWalking = false;
    }

    void Update()
    {
        CharInput();
        controlDrag();
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

        if (verticalMovement == 1 || horizontalMovement == 1)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        if (isWalking && footSteps.isPlaying == false)
        {
            footSteps.Play();
        }
        movementDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;

    }

    void MovePlayer()
    {
        rb.AddForce(movementDirection * moveSpeed *movementMultiplier, ForceMode.Acceleration);
    }
}
