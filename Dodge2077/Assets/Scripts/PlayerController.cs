using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // Player movement Speed

    private bool moveCheck; // isMoving?




    Transform playerPos;
    SpriteRenderer sprites;
    

    void Awake()
    {
        moveSpeed = 10f;
        
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

    void Move()
    {
        
        Vector3 movePosition = Vector3.zero;
        
        moveCheck = false;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            movePosition += Vector3.left;
            sprites.flipX = true;
            moveCheck = true;
            playerPos.localEulerAngles = new Vector3(0, -50, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            movePosition += Vector3.right;
            sprites.flipX = false;
            moveCheck = true;
            playerPos.localEulerAngles = new Vector3(0, 50, 0);
        }
        else
        {
            playerPos.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            movePosition += Vector3.down;
            //moveCheck = true;

        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            movePosition += Vector3.up;
            //moveCheck = true;
        }

        //if (moveCheck) Debug.Log("isMoving!!");

        transform.position += movePosition * moveSpeed * Time.deltaTime;
    }

    void GetInfo()
    { 
        
    }
    


}
