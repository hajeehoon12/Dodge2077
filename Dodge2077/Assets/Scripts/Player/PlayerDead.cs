using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    private PlayerHPSystem hpSystem;

    private void Start()
    {
        hpSystem = GetComponent<PlayerHPSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collider Name : " + other.gameObject.name);
        DataManager.Instance.playerHit += 10;


        if (hpSystem != null)
        {
            switch (other.name)
            {
                case "BulletEnemyTriangle(Clone)":
                    hpSystem.TakeDamage(50.0f);
                    break;
                default:
                    hpSystem.TakeDamage(10.0f);
                    other.gameObject.SetActive(false);
                    break;
            
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "BulletEnemyTriangle(Clone)") hpSystem.TakeDamage(1.0f);
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle Name :" + other.gameObject.name);
        DataManager.Instance.playerHit += 1;

        if (hpSystem != null) hpSystem.TakeDamage(1.0f);
    }
}
