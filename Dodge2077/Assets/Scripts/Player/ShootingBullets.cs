using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullets : MonoBehaviour
{
    public GameObject _bullet;
    public GameObject _poolManager;

    public float _damage; // 총알 데미지
    public int _per; // 총알 관통력
    public float _bulletSpeed; // 총알 속력

    public float coolTime = 1f;
    private float lastFireTime;

    // Start is called before the first frame update


    private void Awake()
    {
        
    }



    void Start()
    {
        _damage = 1;
        _per = 0; // penetrate 0 enemy
        StartCoroutine(Fire(coolTime)); // coolTime 마다 총알을 발사하라
    }

    private IEnumerator Fire(float coolTime)
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(coolTime);
        }
    }

    private void Shoot()
    {
        AudioManager.instance.PlaySFX("Bullet", 0.01f);
        GameObject bullet = PoolManager.Instance.Get(0); // case 0 이 아니기에 prefabId에 총알번호가 들어감
        bullet.transform.position = transform.position;

        bullet.transform.localEulerAngles = new Vector3(0, 0, 0); // 총알의 회전값
        //Debug.Log("test");
        bullet.GetComponent<Bullet>().Init(_damage, _per, _bulletSpeed); // 총알 데미지, 관통력, 속력

        

    }

}
