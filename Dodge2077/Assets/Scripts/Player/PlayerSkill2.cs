using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using DG.Tweening;

public class PlayerSkill2 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player_Skill1;
    public GameObject player_Skill2;
    public GameObject player;

    private bool isPressing = false; // To check pressing
    private bool timeWatch = false; // To check when you start pressing

    public CharacterStatHandler playerStat;

    public BoxCollider2D collider;

    private void Awake()
    {
        playerStat = GetComponent<CharacterStatHandler>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        player_Skill1.SetActive(false);
        player_Skill2.SetActive(false);

        //플레이어 능력치로 초기화 ( Awake에 작성하면 오류가 나온다 )
        playerStat.PlayerInit();
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(timeWatch);
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            //Invoke("Pressing", 0.5f);
            Pressing();
            timeWatch = true;
            // Skill Start Animation
            player_Skill1.SetActive(true);
            player_Skill2.SetActive(true);

            player_Skill1.GetComponent<SkillTriangle>().StartFire(playerStat.CurrentStat.BulletCoolTime);
            player_Skill2.GetComponent<SkillTriangle>().StartFire(playerStat.CurrentStat.BulletCoolTime);
        }


        if (Input.GetKey(KeyCode.Delete) && isPressing)
        {
            // when pressing go for animation of Special Skill
        }
        else if (timeWatch)
        {
            NotPressing();
        }

        if (Input.GetKeyDown(KeyCode.End))
        {
            AudioManager.instance.PlaySFX("MachineGun", 0.1f);
            ShakeCamera.instance.MakeCameraShake(1f, 0.1f, 0.1f);

            for (int i = 0; i < 10; i++)
            {
                GameObject bullet = PoolManager.Instance.Get(1); // case 0 이 아니기에 prefabId에 총알번호가 들어감
                bullet.transform.position = transform.position;


                bullet.transform.localEulerAngles = new Vector3(0, 0, i * 18 - 90); // 총알의 회전값
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
            collision.GetComponent<Item_Abstract>().TakeItem(this);
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
