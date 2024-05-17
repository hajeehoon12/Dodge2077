using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkHyuk : MonoBehaviour
{
    private int patternNum = 0;
    public Transform _player;
    public void CallDark()
    {

        switch (patternNum%3)
        {
            case 0:
                CrazsyShot();
                break;
            case 1:
                ShootStraight();
                break;
            case 2:
                ShootChasing();
                
                break;
            default:
                break;

        }

        patternNum++;
    }

    private void ShootStraight() // Straight Shot
    {

        for (int i = 0; i < 5; i++)
        {
            AudioManager.instance.PlaySFX("Cannon");

            GameObject bullet = GameManager.Instance.pool.Get(2);
            bullet.transform.position = transform.position + new Vector3(-2 + i , 0, 0);
            bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            bullet.transform.localEulerAngles = new Vector3(0, 0, 180); // 총알의 회전값
                                                                        //Debug.Log("test");
            bullet.GetComponent<Bullet>().Init(1, 1, 1); // 총알 데미지, 관통력, 속력
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
        AudioManager.instance.PlaySFX("Bullet", 0.01f);
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

            bullet.transform.localEulerAngles = new Vector3(0, 0, 90 + i * 9); // 총알의 회전값
                                                                               //Debug.Log("test");
            bullet.GetComponent<Bullet>().Init(1, 1, 0.7f); // 총알 데미지, 관통력, 속력
        }
    }





}
