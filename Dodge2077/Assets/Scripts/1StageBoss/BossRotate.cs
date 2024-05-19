using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UI;
using System;

public class BossRotate : MonoBehaviour
{
    public WhiteHyuk _whiteHyuk;
    public DarkHyuk _darkHyuk;
    public HPSystem _HpSys;

    public Text Boss1;
    public Text Boss2;

    private bool isRotate = false; // isRotate = false, dark || isRotate = true , white
    private bool isPatternEnd = false;

    Vector3 firstRotate = new Vector3(0, 0, 180);
    Vector3 secondRotate = new Vector3(0, 0, 360);

    public Coroutine BossCoroutine; // variable to call boss Coroutine
    //public Coroutine BossCoroutinePhase2;

    public bool whiteDead = false;
    public bool blackDead = false;


    // Update is called once per frame



    public void Start()
    {
        Invoke("StartRotate", 3f);
    }

    private void StartRotate()
    {
        BossCoroutine=StartCoroutine(RotateBoss()); // call main Coroutine after 5sec
        //BossCoroutine = StartCoroutine(AngryBoss(true)); // 
    }

    public void BossPhase() // select boss phase
    {

        if (_whiteHyuk.GetComponentInChildren<HPSystem>().CurrentHealth <= 0)
        {
            
            whiteDead = true;// if whiteHyuk is Dead
        }
        if (_darkHyuk.GetComponentInChildren<HPSystem>().CurrentHealth <= 0)  // if darkHyuk is Dead
        {  
            blackDead = true;
        }
        if (whiteDead != blackDead) // one is Dead
        {
            StartCoroutine(SlowMotion());
            StartCoroutine(BossPhase2Sync());
            AudioManager.instance.StopBGM();
            AudioManager.instance.PlayBGM("Boss1Phase2");
            StopCoroutine(BossCoroutine); // make instance to call boss Coroutine
            BossCoroutine = StartCoroutine(AngryBoss(whiteDead)); // if white dead true , else false
        }
        else   // two is Dead
        {
            StartCoroutine(SlowMotion());
            _darkHyuk.GetComponent<Animator>().SetBool("isDead", true);
            _whiteHyuk.GetComponent<Animator>().SetBool("isDead", true);
            StopCoroutine(BossCoroutine);
        }
    }

    private IEnumerator SlowMotion() // Boss Rotate and call Pattern
    {
        ShakeCamera.instance.MakeCameraShake(0.6f, 0.1f, 0.1f);
        Time.timeScale = 0.3f;
        yield return new WaitForSeconds(0.7f);
        Time.timeScale = 1f;
    }

    private IEnumerator BossPhase2Sync() // Boss Rotate and call Pattern
    {
        float time = 0.0f;
        float duration = 0.7f;

        if (whiteDead)
        {
            transform.DORotate(secondRotate, 0.3f);   
            _HpSys = _darkHyuk.GetComponent<HPSystem>();
            DOTween.To(() => "", str => Boss2.text = str, "∫–≥Î«— æÓµ“¿« «ı∏≈¥‘", 1.5f);
            _whiteHyuk.GetComponent<Animator>().SetBool("isDead", true);

        }
        else
        {
            transform.DORotate(firstRotate, 0.3f);
            _HpSys = _whiteHyuk.GetComponent<HPSystem>();
            DOTween.To(() => "", str => Boss1.text = str, "∫–≥Î«— ∫˚¿« «ı∏≈¥‘", 1.5f);
            _darkHyuk.GetComponent<Animator>().SetBool("isDead", true);
        }

        while (time < 1.0f)
        {
            time += 0.01f/ duration;
            if(whiteDead) _HpSys.TakeDamage(-2);
            else _HpSys.TakeDamage(-1.5f);
            yield return null;
            yield return new WaitForSeconds(0.01f);
        }
    }


    private void HyukPattern()
    {
        isPatternEnd = true;
        if (isRotate)
        {
            _whiteHyuk.CallWhite();
            //_darkHyuk.CallDark();
            //call WhiteHyuk Boss Pattern
        }
        else
        {
            //_whiteHyuk.CallWhite();
            _darkHyuk.CallDark();
            //call DarkHyuk Boss Pattern
        }
    }

 

    // UniTask
    private IEnumerator RotateBoss() // Boss Rotate and call Pattern
    {
        while (true)
        {
            isPatternEnd = false;

            if (!isRotate)
            {              
                transform.DORotate(firstRotate, 1).onComplete += HyukPattern; // Rotate 180 degree in 1sec
                
                isRotate = true;
                yield return new WaitUntil(() => isPatternEnd ); // wait until isPatterEnd is true
                yield return new WaitForSeconds(3f);  // wait 3 sec
            }
            else
            {       
                transform.DORotate(secondRotate, 1).onComplete += HyukPattern; // Rotate another 180 degree in 1sec
                isRotate = false;
                yield return new WaitUntil(() => isPatternEnd); // wait until isPatterEnd is true
                yield return new WaitForSeconds(3f); // wait 3 sec
            }
        }
    }


    private IEnumerator AngryBoss(bool ifDark) // Boss Rotate and call Pattern
    {
        //ShakeCamera.instance.MakeCameraShake(2f, 0.2f, 0.2f);
        yield return new WaitForSeconds(2f);
        
        while (true)
        {
            transform.DORotate(firstRotate, 2);
            if (ifDark) _darkHyuk.CallDark();
            else _whiteHyuk.CallWhite();
            yield return new WaitForSeconds(2f);  // 
            transform.DORotate(secondRotate, 2);
            if (ifDark) _darkHyuk.CallDark();
            else _whiteHyuk.CallWhite();
            yield return new WaitForSeconds(2f); // 
            
        }
    }


}