using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkHyuk : MonoBehaviour
{
    private int patternNum = 0;
    public Transform _player;
    public void CallDark()
    {

        switch (patternNum%2)
        {
            case 0:
                ShootChasing();
                break;
            case 1:
                ShootStraight();
                break;
            default:
                break;

        }

        patternNum++;
    }

    private void ShootStraight()
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

    private void ShootChasing()
    {
        for (int i = 0; i < 15; i++)
        {
            Invoke("ShootingStar", i*0.1f);
        }
    }

    private void ShootingStar()
    {
        AudioManager.instance.PlaySFX("Bullet", 0.01f);
        GameObject bullet = GameManager.Instance.pool.Get(4);
        bullet.transform.position = transform.position;
        Vector3 shootDir = _player.transform.position - bullet.transform.position;

        bullet.GetComponent<Bullet>().rigid.velocity = shootDir*1.5f;
    }

   




}
