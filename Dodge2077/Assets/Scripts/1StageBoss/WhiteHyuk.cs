using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteHyuk : MonoBehaviour
{
    // Start is called before the first frame update

    private int patternNum = 0;
    public GameObject Meteor; // skill object
    public Transform _player;

 

    private void Start()
    {
        Meteor.SetActive(false);   
    }


    public void CallWhite()
    {

        switch (patternNum%2)
        {
            case 0:
                MeteorOn(); // Call Meteor Skill
                Invoke("MeteorOff", 3f); // Call Skill Off after 3sec
                break;
            case 1:
                CrazsyShot();
                break;
            default:
                break;
        
        
        
        
        
        }



        patternNum++;
    }

    private void MeteorOn()
    {
        Meteor.SetActive(true);
    }
    private void MeteorOff()
    {
        Meteor.SetActive(false);
    }

    private void CrazsyShot()
    {
        for (int i = 0; i < 20; i++)
        {
            AudioManager.instance.PlaySFX("Laser");

            GameObject bullet = GameManager.Instance.pool.Get(3);
            
            bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            bullet.transform.localEulerAngles = new Vector3(0, 0, 90+i*9); // 총알의 회전값
                                                                        //Debug.Log("test");
            bullet.GetComponent<Bullet>().Init(1, 1, bullet.transform.up*0.2f); // 총알 데미지, 관통력, 속력
        }
    }



}
