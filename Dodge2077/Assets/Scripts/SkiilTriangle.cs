using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTriangle : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject _player;
    public ShootingBullets _shootingBullets;
    public float nextFire;
    public float fireRate = 0.5f;

    // Update is called once per frame
    void Start()
    {
        //StartCoroutine(Firing(_shootingBullets.coolTime));
    }

    public IEnumerator Firing(float coolTime)
    {
        while (true)
        {
            Shooting();
            yield return new WaitForSeconds(coolTime);
        }
    }



    private void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shooting();
        }
    }

    private void Shooting()
    {
        GameObject bullet = GameManager.Instance.pool.Get(0); // case 0 이 아니기에 prefabId에 총알번호가 들어감
        bullet.transform.position = transform.position;

        bullet.transform.localEulerAngles = new Vector3(0, 0, 0); // 총알의 회전값
        
        bullet.GetComponent<Bullet>().Init(_shootingBullets._damage, _shootingBullets._per, new Vector3(0, _shootingBullets._bulletSpeed, 0)); // 총알 데미지, 관통력, 속력
    }


}
