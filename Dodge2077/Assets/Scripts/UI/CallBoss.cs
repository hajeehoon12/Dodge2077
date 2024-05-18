using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CallBoss : MonoBehaviour
{
    public GameObject _boss;


    private void Start()
    {
        transform.DOMove(new Vector3(760,1280,0), 5f);
        _boss.transform.DOMove(new Vector3(0, 2.8f, 0), 3f);
        AudioManager.instance.PlayBGM("Boss1", 0.2f); // volume
    }

}
