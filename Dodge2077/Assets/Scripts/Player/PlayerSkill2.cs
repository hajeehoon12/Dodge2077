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

    //HP�����ý��� ( �̰����� ������� �޴� �� HP���� �ý����� ó���Ѵ� )
    private PlayerHPSystem hpSystem;
    private MPSystem mpSystem;

    public PlayerHPManager _playerHPManager;
    public PlayerMPManager _playerMPManager;

    public BoxCollider2D colliders;

    private void Awake()
    {
        playerStat = GetComponent<CharacterStatHandler>();
        colliders = GetComponent<BoxCollider2D>();
        hpSystem = GetComponent<PlayerHPSystem>();
        mpSystem = GetComponent<MPSystem>();
    }

    private void Start()
    {
        player_Skill1.SetActive(false);
        player_Skill2.SetActive(false);

        //�÷��̾� �ɷ�ġ�� �ʱ�ȭ ( Awake�� �ۼ��ϸ� ������ ���´� )
        playerStat.PlayerInit();

        if (hpSystem != null)
        {
            _playerHPManager.ChangeMaxHP(playerStat.CurrentStat.MaxHP);
            _playerHPManager.ChangeCurrentHP(playerStat.CurrentStat.MaxHP);
            _playerMPManager.ChangeMaxMP(mpSystem.MaxMP);
            _playerMPManager.ChangeCurrentMP(mpSystem.CurrentMP);

            hpSystem.OnDamage += _playerHPManager.TakeDamage;
            hpSystem.OnHeal += _playerHPManager.TakeDamage;
            hpSystem.OnDeath += GameManager.Instance.WhenGameLose;

            mpSystem.OnUseMana += _playerMPManager.UseMana;
            mpSystem.OnFillMana += _playerMPManager.UseMana;
        }
        else Debug.Log("hpSystem is null");
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(timeWatch);
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            if (mpSystem.CurrentMP < 0.1f) return;

            //Invoke("Pressing", 0.5f);
            Pressing();
            timeWatch = true;
            // Skill Start Animation
            player_Skill1.SetActive(true);
            player_Skill2.SetActive(true);

            player_Skill1.GetComponent<SkillTriangle>().StartFire(playerStat.CurrentStat.BulletCoolTime);
            player_Skill2.GetComponent<SkillTriangle>().StartFire(playerStat.CurrentStat.BulletCoolTime);

            mpSystem.UseMana(0.1f);
        }


        if (Input.GetKey(KeyCode.Delete) && isPressing)
        {
            if(mpSystem.CurrentMP < 0.1f) return;

            // when pressing go for animation of Special Skill
            mpSystem.UseMana(0.1f);
        }
        else if (timeWatch)
        {
            NotPressing();
        }

        if (Input.GetKeyDown(KeyCode.End))
        {
            if (mpSystem.CurrentMP < 30.0f) return;

            AudioManager.instance.PlaySFX("MachineGun", 0.1f);
            ShakeCamera.instance.MakeCameraShake(1f, 0.1f, 0.1f);

            for (int i = 0; i < 10; i++)
            {
                GameObject bullet = PoolManager.Instance.Get(1); // case 0 �� �ƴϱ⿡ prefabId�� �Ѿ˹�ȣ�� ��
                bullet.transform.position = transform.position;


                bullet.transform.localEulerAngles = new Vector3(0, 0, i * 18 - 90); // �Ѿ��� ȸ����
                bullet.transform.position += bullet.transform.up * 1.5f;
                //Debug.Log("test");
                bullet.GetComponent<Bullet>().Init(10, 5, 1); // �Ѿ� ������, �����, �ӷ�
            }

            mpSystem.UseMana(30.0f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�����۰� �������� ��( PlayerDead���� �����ʰ� ����� �ۼ��� ������ PlayerStat�� �޾ƿ;� �ϱ� �����̴�. )
        if (collision.CompareTag("Item"))
        {
            //TakeItem�� ȣ��
            collision.GetComponent<Item_Abstract>().TakeItem(this);
            //������ �Ҹ�
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
