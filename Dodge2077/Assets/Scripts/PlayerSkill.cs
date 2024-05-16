using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player_Skill1;
    public GameObject player_Skill2;
    public GameObject player;

    private bool isPressing = false; // To check pressing
    private bool timeWatch = false; // To check when you start pressing


    private void Start()
    {
        player_Skill1.SetActive(false);
        player_Skill2.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

        //Debug.Log(timeWatch);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Invoke("Pressing", 0.5f);
            Pressing();
            timeWatch = true;
            // Skill Start Animation
            player_Skill1.SetActive(true);
            player_Skill2.SetActive(true);
            //StartCoroutine(player_Skill1.GetComponent<SkillTriangle>().Firing(GetComponent<ShootingBullets>().coolTime));
        }


        if (Input.GetKey(KeyCode.Space) && isPressing)
        {
            // when pressing go for animation of Special Skill
        }
        else if(timeWatch)
        {
            //Invoke("NotPressing", 0.4f);
            NotPressing();
        }

    }

    void Pressing()
    { 
        isPressing = true;
        //Debug.Log("asda");
    }
    void NotPressing()
    {
        isPressing = false;
        timeWatch = false;
        player_Skill1.SetActive(false);
        player_Skill2.SetActive(false);
    }



}
