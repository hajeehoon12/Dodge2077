using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using DG.Tweening;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player_Skill1;
    public GameObject player_Skill2;
    public GameObject player;

    private bool isPressing = false; // To check pressing
    private bool timeWatch = false; // To check when you start pressing

    private CharacterStatHandler playerStat;


    private void Awake()
    {
        playerStat = GetComponent<CharacterStatHandler>();
    }

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

            //player_Skill1.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
            //player_Skill2.transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);

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
                GameObject bullet = PoolManager.Instance.Get(1); // case 0 이 아니기에 prefabId에 총알번호가 들어감
                bullet.transform.position = transform.position;


                bullet.transform.localEulerAngles = new Vector3(0, 0, i * 18-90); // 총알의 회전값
                bullet.transform.position += bullet.transform.up * 1.5f;
                                                                          //Debug.Log("test");
                bullet.GetComponent<Bullet>().Init(10, 5, 1); // 총알 데미지, 관통력, 속력
            }


        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //아이템과 접촉했을 시( PlayerDead에다 하지않고 여기다 작성한 이유는 PlayerStat을 받아와야 하기 떄문이다. )
        if (collision.CompareTag("Item"))
        {
            //TakeItem을 호출
            collision.GetComponent<Item_Abstract>().TakeItem(playerStat);
            //아이템 소멸
            Destroy(collision.gameObject);
            //Debug.Log($"Power: {playerStat.CurrentStat.Damage}");
            //Debug.Log($"Speed: {playerStat.CurrentStat.MoveSpeed}");
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
