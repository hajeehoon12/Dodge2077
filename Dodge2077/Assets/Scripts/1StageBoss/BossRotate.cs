using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossRotate : MonoBehaviour
{
    public WhiteHyuk _whiteHyuk;
    public DarkHyuk _darkHyuk;

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
        
        if (_whiteHyuk.GetComponentInChildren<HPSystem>().CurrentHealth <= 0) // if whiteHyuk is Dead
        {
            BossPerformance();
            whiteDead = true;
            transform.DORotate(secondRotate, 0.3f);
            DOTween.To(() => _darkHyuk.GetComponentInChildren<HPSystem>().CurrentHealth, x => _darkHyuk.GetComponentInChildren<HPSystem>().CurrentHealth = x, 100f, 0.6f);
        }
        if (_darkHyuk.GetComponentInChildren<HPSystem>().CurrentHealth <= 0) // if darkHyuk is Dead
        {
            BossPerformance();
            blackDead = true;
            transform.DORotate(firstRotate, 0.3f);
        }


        if (whiteDead != blackDead) // one is Dead
        {
            AudioManager.instance.StopBGM();
            AudioManager.instance.PlayBGM("Boss1Phase2");
            StopCoroutine(BossCoroutine); // make instance to call boss Coroutine
            BossCoroutine = StartCoroutine(AngryBoss(whiteDead)); // if white dead true , else false
        }
        else   // two is Dead
        {
            ShakeCamera.instance.MakeCameraShake(1f, 0.1f, 0.1f); ;
            StopCoroutine(BossCoroutine);
        }
    }

    private void BossPerformance()
    {
        Time.timeScale = 0.3f;
        Invoke("BossPerformanceBack", 0.7f);
    }
    private void BossPerformanceBack()
    {
        Time.timeScale = 1f;
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
        ShakeCamera.instance.MakeCameraShake(2f, 0.2f, 0.2f);
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