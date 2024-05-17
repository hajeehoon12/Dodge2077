using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossRotate : MonoBehaviour
{
    public GameObject LightBoss;
    public GameObject DarkBoss;

    // Update is called once per frame

    public void Start()
    {
        RotateBoss();
    }


    public void RotateBoss()
    {
        transform.DORotate(new Vector3 (0, 0, 180), 1);
    }
}
