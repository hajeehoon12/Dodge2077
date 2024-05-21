using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController2 : MonoBehaviour
{
    //private bool moveCheck; // isMoving?

    float runSpeed;
    float rotateAdd;


    Transform playerPos;
    SpriteRenderer sprites;

    private CharacterStatHandler playerStat;

    void Awake()
    {
        playerStat = GetComponent<CharacterStatHandler>();
        sprites = GetComponentInChildren<SpriteRenderer>();
        playerPos = GetComponentInChildren<Transform>();
        if (DataManager.Instance.is1P)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        
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



        if (Input.GetAxisRaw("Horizontals") < 0)
        {
            if (playerPos.position.x < -2.4) return; // Left Side Screen

            movePosition += Vector3.left * runSpeed;
            sprites.flipX = true;
            //moveCheck = true;
            playerPos.localEulerAngles = new Vector3(0, -50 - rotateAdd, 0); // left rotation
        }
        else if (Input.GetAxisRaw("Horizontals") > 0)
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
        if (Input.GetAxisRaw("Verticals") < 0)
        {
            if (playerPos.position.y < -4.5) return;

            movePosition += Vector3.down;
            //moveCheck = true;

        }
        else if (Input.GetAxisRaw("Verticals") > 0)
        {
            if (playerPos.position.y > 4.7) return;

            movePosition += Vector3.up;
            //moveCheck = true;
        }

        //if (moveCheck) Debug.Log("isMoving!!");

        transform.position += movePosition * playerStat.CurrentStat.MoveSpeed * Time.fixedDeltaTime;
    }

    public void ChangeSpeed(float speed)
    {
        playerStat.ChangeMoveSpeed(speed);
    }

    public void HalfSpeed()
    {
        playerStat.HalfMoveSpeed();
    }
    public void DoubleSpeed()
    {
        playerStat.CallBackMoveSpeed();
    }


}
