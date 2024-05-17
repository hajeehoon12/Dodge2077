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
    public void CallDark()
    {

        switch (patternNum%4)
        {
            case 0:
                FanShot();
                
                break;
            case 1:
                ShootStraight();
                break;
            case 2:
                ShootChasing();
                break;
            case 3:
                CrazsyShot();
                break;
            default:
                break;

        }

        patternNum++;
    }

    private void FanShot() // Fan Range Shot
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

        for (int i = 0; i < 5; i++)
        {
            AudioManager.instance.PlaySFX("Cannon");

            GameObject bullet = GameManager.Instance.pool.Get(2);
            bullet.transform.position = transform.position + new Vector3(-2 + i , 0, 0);
            bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            bullet.transform.localEulerAngles = new Vector3(0, 0, 180); // �Ѿ��� ȸ����
                                                                        //Debug.Log("test");
            bullet.GetComponent<Bullet>().Init(1, 1, 1); // �Ѿ� ������, �����, �ӷ�
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
        for (int i = 0; i < 20; i++)
        {
            AudioManager.instance.PlaySFX("Laser");

            GameObject bullet = GameManager.Instance.pool.Get(4);

            bullet.transform.position = transform.position;

            bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            bullet.transform.localEulerAngles = new Vector3(0, 0, 90 + i * 9); // �Ѿ��� ȸ����
                                                                               //Debug.Log("test");
            bullet.GetComponent<Bullet>().Init(1, 1, 0.7f); // �Ѿ� ������, �����, �ӷ�
        }
    }





}
