using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteHyuk : MonoBehaviour
{
    // Start is called before the first frame update

    private int patternNum = 0;
    public GameObject Meteor; // skill object
    public Transform _player;
    GameObject chasingBullet;



    private void Start()
    {
        Meteor.SetActive(false);   
    }


    public void CallWhite()
    {

        switch (patternNum%2)
        {
            case 0:
                AdvancedChasing();
                break;
            case 1:
                CrazsyShot();
                break;
            case 2:
                StoneShot();
                break;

            default:
                break;
        }

        patternNum++;
    }

    private void AdvancedChasing() // Player Chasing shot for 6 seconds
    {
        chasingBullet = GameManager.Instance.pool.Get(5);
        chasingBullet.transform.position = transform.position;


        chasingBullet.transform.localEulerAngles = new Vector3(0, 0, 0); // 총알의 회전값
        //Debug.Log("test");

        StartCoroutine(ChasingTime(6f));

        //
        //bullet.transform.DORotate(new Vector3(0, 0, 1080), 3);

        
    }

    public IEnumerator ChasingTime(float duration) // Working to chase
    {
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
        for (int i = 0; i < 20; i++)
        {
            AudioManager.instance.PlaySFX("Laser");

            GameObject bullet = GameManager.Instance.pool.Get(3);

            bullet.transform.position = transform.position;

            bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            bullet.transform.localEulerAngles = new Vector3(0, 0, 90 + i * 9); // 총알의 회전값
                                                                               //Debug.Log("test");
            bullet.GetComponent<Bullet>().Init(1, 1, 0.7f); // 총알 데미지, 관통력, 속력
        }
    }


    private void StoneShot() // meteor shot with magical 
    {
        AudioManager.instance.PlaySFX("Stone", 1f);
        Meteor.transform.position -= new Vector3((Meteor.transform.position.x - _player.position.x), 0, 0);
        Invoke("MeteorOn", 1f); // Call Meteor Skill
        Invoke("MeteorOff", 3f); // Call Skill Off after 3sec
    }
    private void MeteorOn() // assistant
    {
        Meteor.SetActive(true);
    }
    private void MeteorOff() // assistant
    {
        Meteor.SetActive(false);
    }

    



}
