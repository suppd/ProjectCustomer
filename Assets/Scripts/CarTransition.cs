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

    float speed = 20f;
    float carSpeed = 20f;
    //float stopSpeed = 0.0f;
    //float turnSpeed = 90;
    float maxSpeed = 30f;
    float minSpeed = 20f;
    float timer = 0f;

    float verticalMovement;

    public bool playerIn = false;
    public bool startMoving =false;
    bool canChange = true;

    private void Start()
    {
        CarRb.freezeRotation = true;
        //startMoving = false;
        timer = 0f;
    }

    private void FixedUpdate()
    {
       
    }
    void Update()
    {
        PlayerPos = GameObject.FindWithTag("Player").transform;
        InCarPosition = GameObject.FindWithTag("Seat").transform;
        ExitPoint = GameObject.FindWithTag("Exit").transform;

        if (playerIn == true)
        {
            
            PlayerPos.position = InCarPosition.transform.position;
            //transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
            //CarRb.velocity = transform.right * carSpeed;
        }
        else
        {
            //CarRb.constraints = RigidbodyConstraints.FreezePosition;
        }

        if (carSpeed > maxSpeed)
        {
            carSpeed = maxSpeed;
        }
        if (carSpeed <= minSpeed)
        {
            carSpeed = minSpeed;
        }

        if (Input.GetKey(KeyCode.W) && playerIn == true)
        {
            carSpeed += 0.1f; 
        }

        if (Input.GetKey(KeyCode.S) && playerIn == true)
        {    
            carSpeed -= 0.1f;
        }




        if (Vector3.Distance(PlayerPos.position, transform.position) < 10)
        {
            if (Input.GetKey(KeyCode.E) && playerIn == false)
            {

                    Pmove.moveSpeed = 0f;
                    Pmove.movementMultiplier = 0f;
                    PlayerRb.useGravity = false;
                    PlayerPos.position = InCarPosition.transform.position;
                    playerIn = true;
                    speed = carSpeed; 
            }
            else
            {
                //if (Input.GetKey(KeyCode.E) && PlayerIn == true)
                //{
                //    if (CanChange == true)
                //    {
                //        CanChange = false;
                //        StartCoroutine(Change());
                //        Pmove.moveSpeed = 9f;
                //        Pmove.movementMultiplier = 10f;
                //        PlayerRb.useGravity = true;
                //        PlayerIn = false;
                //        speed = stopSpeed;
                //    }
                //}
            }
        }
        //print(carSpeed);

        if (playerIn)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                startMoving = true;
            }
        }
    }

    IEnumerator Change()
    { 
        yield return new WaitForSeconds(2);
        canChange = true;
    }
 
}
