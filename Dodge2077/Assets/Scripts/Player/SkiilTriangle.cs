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
    public Coroutine coroutine;

    private CharacterStatHandler playerStat;

    // Update is called once per frame
    void Start()
    {
        playerStat = _player.GetComponent<CharacterStatHandler>();
    }

    public void StartFire(float cooltime)
    {
        coroutine = StartCoroutine(Firing(cooltime));
    }



    public IEnumerator Firing(float coolTime)
    {
        yield return null;
        while (true)
        {
            Shooting();
            yield return new WaitForSeconds(coolTime);
        }
    }

    public void StopFire()
    {
        StopCoroutine(coroutine);
    }

    private void Shooting()
    {
        float _damage = playerStat.CurrentStat.Damage;
        int _per = playerStat.CurrentStat.Penetration;
        float _bulletSpeed = playerStat.CurrentStat.BulletSpeed;

        AudioManager.instance.PlaySFX("Bullet", 0.01f);
        GameObject bullet = PoolManager.Instance.Get(0); // case 0 이 아니기에 prefabId에 총알번호가 들어감
        bullet.transform.position = transform.position;

        bullet.transform.localEulerAngles = new Vector3(0, 0, 0); // 총알의 회전값
        
        bullet.GetComponent<Bullet>().Init(_damage, _per, _bulletSpeed); // 총알 데미지, 관통력, 속력
    }


}
