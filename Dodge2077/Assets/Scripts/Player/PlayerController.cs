using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // Player movement Speed

    //private bool moveCheck; // isMoving?

    float runSpeed;
    float rotateAdd;


    Transform playerPos;
    SpriteRenderer sprites;
    

    void Awake()
    {
      
        
    }

    private void Start()
    {
        sprites = GetComponentInChildren<SpriteRenderer>();
        playerPos = GetComponentInChildren<Transform>();
    }
    void FixedUpdate()
    {
        Move(); // get moveO
    }
    private void Update()
    {

    }

    void Move() // basic Move
    {
        
        Vector3 movePosition = Vector3.zero;
        runSpeed = 1;
        rotateAdd = 0;
        //moveCheck = false;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            runSpeed = 1.5f;
            rotateAdd = 10;
        }
        


        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            if (playerPos.position.x < -2.4) return; // Left Side Screen

            movePosition += Vector3.left * runSpeed;
            sprites.flipX = true;
            //moveCheck = true;
            playerPos.localEulerAngles = new Vector3(0, -50 - rotateAdd, 0); // left rotation
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if (playerPos.position.x > 2.4) return; // Right Side Screen 

            movePosition += Vector3.right * runSpeed;
            sprites.flipX = false;
            //moveCheck = true;
            playerPos.localEulerAngles = new Vector3(0, 50 + rotateAdd, 0); // right rotation
        }
        else
        {
            playerPos.localEulerAngles = new Vector3(0, 0, 0); // init rotation when no input
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            if (playerPos.position.y < -4.5) return;

            movePosition += Vector3.down;
            //moveCheck = true;

        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (playerPos.position.y > 4.7) return;

            movePosition += Vector3.up;
            //moveCheck = true;
        }

        //if (moveCheck) Debug.Log("isMoving!!");

        transform.position += movePosition * moveSpeed * Time.fixedDeltaTime;
    }

    public void ChangeSpeed(float speed)
    { 
        moveSpeed = speed;
    }

}
