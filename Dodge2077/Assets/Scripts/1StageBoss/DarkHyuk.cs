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
                ShootStraight();
                break;
            case 1:
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
            bullet.GetComponent<Bullet>().Init(1, 1, new Vector3(0, 3, 0)); // 총알 데미지, 관통력, 속력
        }
    }

    


}
