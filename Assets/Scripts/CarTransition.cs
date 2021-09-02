using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTransition : MonoBehaviour
{
    public Rigidbody CarRb;
    public Rigidbody PlayerRb;
    public PlayerMovement Pmove;

    Transform ExitPoint;
    Transform InCarPosition;
    Transform PlayerPos;

    Vector3 movementDirection;

    public float speed = 2f;
    public float carSpeed = 2f;
    public float stopSpeed = 0.0f;
    public float turnSpeed = 90;
    public float movementMultiplier = 1f;

    float verticalMovement;

    bool PlayerIn = false;
    bool CanChange = true;

    private void Start()
    {
        CarRb.freezeRotation = true;
    }
    void CarInput()
    {
        
        verticalMovement = Input.GetAxis("Vertical");

        movementDirection = transform.forward * verticalMovement + transform.right;

    }

    private void FixedUpdate()
    {
       
    }
    void Update()
    {
        
        
        PlayerPos = GameObject.FindWithTag("Player").transform;
        InCarPosition = GameObject.FindWithTag("Seat").transform;
        ExitPoint = GameObject.FindWithTag("Exit").transform;

        


        if (PlayerIn == true)
        {
            
            PlayerPos.position = InCarPosition.transform.position;
            transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
        }
        else
        {
            
        }

        if (Input.GetKey(KeyCode.W) && PlayerIn == true)
        {
            CarRb.velocity = transform.right * speed * Input.GetAxis("Car");

        }

        else
        {
            CarRb.velocity = CarRb.velocity * 0.99f;
        }



        if (Vector3.Distance(PlayerPos.position, transform.position) < 10)
        {
            if (Input.GetKey(KeyCode.E) && PlayerIn == false)
            {
                if (CanChange == true)
                {
                    CanChange = false;
                    StartCoroutine(Change());
                    Pmove.moveSpeed = 0f;
                    Pmove.movementMultiplier = 0f;
                    PlayerRb.useGravity = false;
                    PlayerPos.position = InCarPosition.transform.position;
                    PlayerIn = true;
                    speed = carSpeed;
                    transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.E) && PlayerIn == true)
                {
                    if (CanChange == true)
                    {
                        CanChange = false;
                        StartCoroutine(Change());
                        Pmove.moveSpeed = 9f;
                        Pmove.movementMultiplier = 10f;
                        PlayerRb.useGravity = true;
                        PlayerIn = false;
                        speed = stopSpeed;
                    }
                }
            }
        }
        print(CanChange);
    }

    IEnumerator Change()
    { 
        yield return new WaitForSeconds(1);
        CanChange = true;
    }
 
}
