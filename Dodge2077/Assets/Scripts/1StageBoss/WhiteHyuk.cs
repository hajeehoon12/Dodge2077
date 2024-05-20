using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class WhiteHyuk : MonoBehaviour
{
    // Start is called before the first frame update

    private int patternNum = 0;
    public GameObject Meteor; // skill object
    public Transform _player;
    GameObject chasingBullet;
    public GameObject InstantFreezeCircle;
    private GameObject FreezeCircle; // freeze Circle prefab
    public GameObject freezeHit;
    public GameObject Portal; // portal prefab
    public BossHPManager _MyHP;

    //����
    private CharacterStatHandler stat;
    //HP�����ý��� ( �̰����� ������� �޴� �� HP���� �ý����� ó���Ѵ� )
    public HPSystem hpSystem;

    private void Awake()
    {
        //���� ���� ������Ʈ �߰� ( HPSystem��ũ��Ʈ�� �ݵ�� CharacterStatHandler�� ���� ������Ʈ�� �־�� �Ѵ� )
        stat = GetComponent<CharacterStatHandler>();
        hpSystem = GetComponent<HPSystem>();

        FreezeCircle =Instantiate(InstantFreezeCircle);
    }


    private void Start()
    {
        Meteor.SetActive(false);   
        FreezeCircle.SetActive(false);
        freezeHit.SetActive(false);

        if (_MyHP != null)
        {
            //���� HPBar�� �ִ� HP���� �������� ���� ü������ �����ִ� �ڵ�
            _MyHP.ChangeMaxHP(stat.CurrentStat.MaxHP);
            _MyHP.ChangeCurrentHP(stat.CurrentStat.MaxHP);

            //ĳ���Ͱ� �ǰ� ���� ������ ȣ������ �Լ� �߰����� ( hpSystem.OnDamage�� �ǰ� ��ų� ȸ���� ������ �߻��ϴ� �̺�Ʈ )
            hpSystem.OnDamage += _MyHP.TakeDamage;      //OnDamage�� �߻��� ������ _MyHP.TakeDamage�Լ��� ȣ����
            hpSystem.OnHeal += _MyHP.TakeDamage;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Bullet>() != null) hpSystem.TakeDamage(collision.GetComponent<Bullet>().damage);
    }


    public void CallWhite()
    {

        switch (patternNum%4)
        {
            case 0:
                StoneShot();
                
                break;
            case 1:
                Freezing();
                break;
            case 2:
                AdvancedChasing();
                break;
            case 3:
                CreatePortal();
                break;
            default:
                CrazsyShot();
                break;
        }

        patternNum++;
    }

    private void CreatePortal()
    {
        AudioManager.instance.PlaySFX("PortalMagic", 0.3f);
        StartCoroutine(CallPortal(2.5f));
    }


    public IEnumerator CallPortal(float duration) // Working to chase
    {
        float time = 0.0f;
        int count = 0;
        float waitTime = 0.2f;

        while (time < 1.0f)
        {
            time += waitTime / duration;


            GameObject ranPortal = Instantiate(Portal, new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(2.5f, 4.5f), 0), Quaternion.identity);
            GameObject bullet = PoolManager.Instance.Get(3);
            bullet.transform.position = ranPortal.transform.position;

            Vector3 dir = _player.position - ranPortal.transform.position;

            //ranPortal.transform.rotation = Quaternion.LookRotation(dir);

            bullet.GetComponent<Bullet>().rigid.velocity = dir * 1.5f;
            Destroy(ranPortal, 1f); // Destroy after 1sec
            count++;
            yield return null;
            yield return new WaitForSeconds(waitTime); // wait 3 sec
            
            
        }
    }




    private void Freezing()
    {
        freezeHit.SetActive(true);
        freezeHit.GetComponent<Rigidbody2D>().gravityScale = 0;
        freezeHit.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        freezeHit.transform.position = new Vector3(Random.Range(-1,2)* 2 , 4, 0);
        Random.Range(-1, 2);
        FreezeCircle.SetActive(true);
        

        Invoke("FreezeMove", 1f);
        AudioManager.instance.PlaySFX("FreezeMagic");
        StartCoroutine(FreezeTime(7.8f));
    }

    private void FreezeMove()
    {
        freezeHit.GetComponent<Rigidbody2D>().gravityScale = 2;
    }

    public IEnumerator FreezeTime(float duration) // Working to chase
    {
        float time = 0.0f;
        _player.GetComponent<PlayerController>().HalfSpeed();
        while (time < 1.0f)
        {
            time += Time.deltaTime / duration;

            

            yield return null;
        }
        FreezeCircle.SetActive(false);

        _player.GetComponent<PlayerController>().DoubleSpeed();
    }


    private void AdvancedChasing() // Player Chasing shot for 6 seconds
    {
        chasingBullet = PoolManager.Instance.Get(5);
        chasingBullet.transform.position = transform.position;


        chasingBullet.transform.localEulerAngles = new Vector3(0, 0, 0); // �Ѿ��� ȸ����
        //Debug.Log("test");
        AudioManager.instance.PlaySFX("ChasingMagic", 0.5f);
        StartCoroutine(ChasingTime(6f));

        //
        //bullet.transform.DORotate(new Vector3(0, 0, 1080), 3);

        
    }

    public IEnumerator ChasingTime(float duration) // Working to chase
    {
        yield return new WaitForSeconds(0.3f);
        float time = 0.0f;

        while (time < 1.0f)
        {
            time += Time.deltaTime / duration;

            Vector3 shootDir = _player.transform.position - chasingBullet.transform.position;
            shootDir = shootDir.normalized;
            chasingBullet.GetComponent<Bullet>().rigid.velocity = shootDir * 2.5f;
            //chasingBullet.GetComponent<Bullet>().rigid.AddForce(shootDir * 0.3f, ForceMode2D.Impulse);

            yield return null;
        }
    }


    private void CrazsyShot() // 20 shots for arc
    {
        AudioManager.instance.PlaySFX("Laser", 0.5f);

        for (int i = 0; i < 20; i++)
        {

            GameObject bullet = PoolManager.Instance.Get(3);

            bullet.transform.position = transform.position;

            bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            bullet.transform.localEulerAngles = new Vector3(0, 0, 90 + i * 9); // �Ѿ��� ȸ����
                                                                               //Debug.Log("test");
            bullet.GetComponent<Bullet>().Init(1, 1, 0.7f); // �Ѿ� ������, �����, �ӷ�
        }
    }


    private void StoneShot() // meteor shot with magical 
    {
        AudioManager.instance.PlaySFX("Stone", 0.5f);
        Meteor.transform.position -= new Vector3((Meteor.transform.position.x - _player.position.x), 0, 0);
        Invoke("MeteorOn", 0.5f); // Call Meteor Skill
        Invoke("MeteorOff", 3f); // Call Skill Off after 3sec
    }
    private void MeteorOn() // assistant
    {
        Meteor.SetActive(true);
        StartCoroutine(MeteorChase(2f));
    }

    public IEnumerator MeteorChase(float duration) // Working to chase
    {
        
        float time = 0.0f;

        while (time < 1.0f)
        {
            time += Time.deltaTime / duration;

            Meteor.transform.DOMove(Meteor.transform.position - new Vector3((Meteor.transform.position.x - _player.position.x) * 0.8f, 0, 0), 2f);

            yield return null;
            yield return new WaitForSeconds(1f);
        }
    }

    private void MeteorOff() // assistant
    {
        Meteor.SetActive(false);
    }
}
