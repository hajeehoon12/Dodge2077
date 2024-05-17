using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Name : " + collision.gameObject.name);
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("I crashed in particle");
    }
}
