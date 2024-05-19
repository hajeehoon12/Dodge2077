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

    //스탯
    private CharacterStatHandler stat;
    //HP관리시스템 ( 이곳에서 대미지를 받는 등 HP관련 시스템을 처리한다 )
    private HPSystem hpSystem;

    private void Awake()
    {
        //스탯 관련 컴포넌트 추가 ( HPSystem스크립트는 반드시 CharacterStatHandler와 같은 오브젝트에 있어야 한다 )
        stat = GetComponent<CharacterStatHandler>();
        hpSystem = GetComponent<HPSystem>();
    }

    private void Start()
    {
        if (_MyHP != null)
        {
            //보스 HPBar에 있는 HP관련 변수들을 현재 체력으로 맞춰주는 코드
            _MyHP.ChangeMaxHP(stat.CurrentStat.MaxHP);
            _MyHP.ChangeCurrentHP(stat.CurrentStat.MaxHP);

            //캐릭터가 피가 닳을 때마다 호출해줄 함수 추가해줌 ( hpSystem.OnDamage는 피가 닳거나 회복할 때마다 발생하는 이벤트 )
            hpSystem.OnDamage += _MyHP.TakeDamage;      //OnDamage가 발생할 때마다 _MyHP.TakeDamage함수를 호출함
        }
    }

    public void CallDark()
    {

        switch (patternNum%4)
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


    IEnumerator MoveBoss()
    {
        var tween = _Boss.transform.DOMove(new Vector3(-2, 3, 0), 1f);
        yield return tween.WaitForCompletion();
        tween = _Boss.transform.DOMove(new Vector3(2, 3, 0), 1f);
        yield return tween.WaitForCompletion();
        _Boss.transform.DOMove(new Vector3(0, 2.8f, 0), 1f);
    }
    private void FanShot() // Fan Range Shot
    {

        StartCoroutine(MoveBoss());
        AudioManager.instance.PlaySFX("LaserMulti", 0.5f);
        StartCoroutine(CallFan(3f));

    }

    public IEnumerator CallFan(float duration) // Working to chase
    {
        float time = 0.0f;
        
        while (time < 4.0f)
        {
            time += 0.2f;
            for (int i = 0; i < 5; i++)
            {
                GameObject bullet = GameManager.Instance.pool.Get(4);
                bullet.transform.position = transform.position;
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

            for (int i = 0; i < 5; i++)
            {
                AudioManager.instance.PlaySFX("Cannon");

                GameObject bullet = GameManager.Instance.pool.Get(2);
                bullet.transform.position = transform.position + new Vector3(-2 + i + 0.5f * (time%2) , 0, 0);
                bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

                bullet.transform.localEulerAngles = new Vector3(0, 0, 180); // 총알의 회전값
                                                                            //Debug.Log("test");
                bullet.GetComponent<Bullet>().Init(1, 1, 1); // 총알 데미지, 관통력, 속력
            }

            yield return null;
            yield return new WaitForSeconds(0.2f);
        }
    }


    private void ShootChasing() // half - chasing shot for 15 shots
    {
        for (int i = 0; i < 15; i++)
        {
            Invoke("ShootingStar", i*0.1f);
        }
    }

    private void ShootingStar() // assistant 15 shots
    {
        AudioManager.instance.PlaySFX("Bullet", 0.1f);
        GameObject bullet = GameManager.Instance.pool.Get(4);
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

        int time = 0;

        while (time < 5)
        {
            time += 1;

            for (int i = 0; i < 20; i++)
            {
                AudioManager.instance.PlaySFX("Laser");

                GameObject bullet = GameManager.Instance.pool.Get(4);

                bullet.transform.position = transform.position;

                bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f) * time/2.5f;

                bullet.transform.localEulerAngles = new Vector3(0, 0, 90 + (i * 9)); // 총알의 회전값
                                                                                   //Debug.Log("test");
                bullet.GetComponent<Bullet>().Init(1, 1, 0.7f); // 총알 데미지, 관통력, 속력
            }

            yield return null;
            yield return new WaitForSeconds(0.4f);
        }
    }






}
