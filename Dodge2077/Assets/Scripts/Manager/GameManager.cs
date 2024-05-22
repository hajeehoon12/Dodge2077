using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void SceneChanged()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("MainScene");
    }

    


    public void GoMain()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("StartScene");
    }

    public void StageEnd(float Time)
    {
        AudioManager.instance.StopBGM();
        AudioManager.instance.PlayBGM("Victory");
        ShakeCamera.instance.MakeCameraShake(6f, 0.05f, 0.1f);
        StartCoroutine(EndMotion(Time));
        
    }

    private IEnumerator EndMotion(float Time)
    {
        yield return new WaitForSeconds(10f);
        AudioManager.instance.StopBGM();
        DOTween.KillAll();
        DataManager.Instance.IsHighScoreChanged(Time);
        SceneManager.LoadScene("GameWin");
    }

    public void WhenGameLose()
    {
        GameObject.Find("Player").gameObject.SetActive(false);
        GameObject.Find("Player2").gameObject.SetActive(false);

        ShakeCamera.instance.MakeCameraShake(6f, 0.05f, 0.1f);
        StartCoroutine(PlayerDieMotion());
        AudioManager.instance.StopBGM();
        DOTween.KillAll();
    }

    private IEnumerator PlayerDieMotion()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("GameOver");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
