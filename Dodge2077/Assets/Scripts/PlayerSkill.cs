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
            player_Skill1.GetComponent<SkillTriangle>().StartFire(GetComponent<ShootingBullets>().coolTime);
            player_Skill2.GetComponent<SkillTriangle>().StartFire(GetComponent<ShootingBullets>().coolTime);
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

        if (Input.GetKeyDown(KeyCode.C))
        {
            AudioManager.instance.PlaySFX("MachineGun", 0.1f);
            ShakeCamera.instance.MakeCameraShake(1f, 0.1f, 0.1f);

            for (int i = 0; i < 10; i++)
            {
                GameObject bullet = GameManager.Instance.pool.Get(3); // case 0 이 아니기에 prefabId에 총알번호가 들어감
                bullet.transform.position = transform.position;


                bullet.transform.localEulerAngles = new Vector3(0, 0, i * 18-90); // 총알의 회전값
                bullet.transform.position += bullet.transform.up * 1.5f;
                                                                          //Debug.Log("test");
                bullet.GetComponent<Bullet>().Init(10, 5, new Vector3(0, 1.5f, 0)); // 총알 데미지, 관통력, 속력
            }


        }

    }

    void Pressing()
    { 
        isPressing = true;
        
    }
    void NotPressing()
    {
        isPressing = false;
        timeWatch = false;
        player_Skill1.SetActive(false);
        player_Skill1.GetComponent<SkillTriangle>().StopFire();


        player_Skill2.SetActive(false);
        player_Skill2.GetComponent<SkillTriangle>().StopFire();

    }



}
