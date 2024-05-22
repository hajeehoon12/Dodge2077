using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using DG.Tweening;
using static UnityEditor.PlayerSettings;

public class DarkHyuk : MonoBehaviour
{
    private int patternNum = 0;
    public Transform _player;
    public GameObject _Boss;
    public BossHPManager _MyHP;

    //����
    private CharacterStatHandler stat;
    //HP�����ý��� ( �̰����� ������� �޴� �� HP���� �ý����� ó���Ѵ� )
    private BossHPSystem hpSystem;

    private void Awake()
    {
        //���� ���� ������Ʈ �߰� ( HPSystem��ũ��Ʈ�� �ݵ�� CharacterStatHandler�� ���� ������Ʈ�� �־�� �Ѵ� )
        stat = GetComponent<CharacterStatHandler>();
        hpSystem = GetComponent<BossHPSystem>();
    }

    private void Start()
    {
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

    public void CallDark()
    {

        switch (patternNum % 4)// // Random.Range(0,4)
        {
            case 0:
                FanShot();
                
                break;
            case 1:
                CrazsyShot();
                break;
            case 2:
                ShootChasing();
                break;
            case 3:
                ShootStraight();
                break;
            default:
                break;

        }

        patternNum++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>() != null) hpSystem.TakeDamage(collision.GetComponent<Bullet>().damage);
    }


    
    private void FanShot() // Moving Fan Range Shot
    {

        StartCoroutine(MoveBoss());
        AudioManager.instance.PlaySFX("LaserMulti", 0.5f);
        StartCoroutine(CallFan(3f));

    }
    IEnumerator MoveBoss()
    {
        var tween = _Boss.transform.DOMove(new Vector3(-2, 3, 0), 1f);
        yield return tween.WaitForCompletion();
        tween = _Boss.transform.DOMove(new Vector3(2, 3, 0), 1f);
        yield return tween.WaitForCompletion();
        _Boss.transform.DOMove(new Vector3(0, 2.8f, 0), 1f);
    }

    public IEnumerator CallFan(float duration) // Working to chase
    {
        float time = 0.0f;
        
        while (time < 4.0f)
        {
            time += 0.2f;
            for (int i = 0; i < 5; i++)
            {
                GameObject bullet = PoolManager.Instance.Get(4);
                bullet.transform.position = transform.position + new Vector3(i/5,0,0);
                bullet.transform.localEulerAngles = new Vector3(0, 0, 162 + i * 9);
                bullet.GetComponent<Bullet>().Init(1, 1, 0.3f);
                //yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }



    private void ShootStraight() // Straight Shot
    {
        StartCoroutine(StraightMultiple(2f));
        
    }

    public IEnumerator StraightMultiple(float duration) // Working to chase
    {

        int time = 0;

        while (time < 5)
        {
            time += 1;

            AudioManager.instance.PlaySFX("Cannon", 0.2f);

            for (int i = 0; i < 5; i++)
            {
                GameObject bullet = PoolManager.Instance.Get(2);
                bullet.transform.position = transform.position + new Vector3(-2 + i + 0.5f * (time%2) , 0, 0);
                bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

                bullet.transform.localEulerAngles = new Vector3(0, 0, 180); // �Ѿ��� ȸ����
                                                                            //Debug.Log("test");
                bullet.GetComponent<Bullet>().Init(1, 1, 1); // �Ѿ� ������, �����, �ӷ�
            }

            yield return null;
            yield return new WaitForSeconds(0.2f);
        }
    }


    private void ShootChasing() // half - chasing shot for 15 shots
    {
        for (int i = 0; i < 25; i++)
        {
            Invoke("ShootingStar", i*0.1f);
        }
    }

    private void ShootingStar() // assistant 25 shots
    {
        AudioManager.instance.PlaySFX("Bullet", 0.1f);
        GameObject bullet = PoolManager.Instance.Get(4);
        bullet.transform.localScale = Vector3.one;
        bullet.transform.position = transform.position;
        Vector3 shootDir = _player.transform.position - bullet.transform.position;

        bullet.GetComponent<Bullet>().rigid.velocity = shootDir*1.5f;
    }

    private void CrazsyShot() // 20 shots for arc
    {
        StartCoroutine(CrazyShotMulti(2f));
    }
    public IEnumerator CrazyShotMulti(float duration) // Working to chase
    {

        float time = 0;

        while (time < 5)
        {
            time += 1;
            AudioManager.instance.PlaySFX("Laser", 0.2f);
            for (int i = 0; i < 20; i++)
            {
                

                GameObject bullet = PoolManager.Instance.Get(4);

                bullet.transform.position = transform.position + new Vector3 (time/20,0,0);

                bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f) * (time/3+1f);

                bullet.transform.localEulerAngles = new Vector3(0, 0, 90 + (i * 9)); // �Ѿ��� ȸ����
                                                                                   //Debug.Log("test");
                bullet.GetComponent<Bullet>().Init(1, 1, 0.7f); // �Ѿ� ������, �����, �ӷ�
            }

            yield return null;
            yield return new WaitForSeconds(0.4f);
        }
        
    }






}
