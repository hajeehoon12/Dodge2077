using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collider Name : " + other.gameObject.name);
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle Name :" + other.gameObject.name);
    }
}
