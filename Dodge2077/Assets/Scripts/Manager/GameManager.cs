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
        SceneManager.LoadScene("MainScene");
    }
    public void StageEnd(float Time)
    {
        AudioManager.instance.StopBGM();
        
        StartCoroutine(EndMotion(Time));
        
    }

    private IEnumerator EndMotion(float Time)
    {


        AudioManager.instance.PlayBGM("Victory");
        yield return new WaitForSeconds(10f);
        AudioManager.instance.StopBGM();
        SceneManager.LoadScene("StartScene");
        DataManager.Instance.IsHighScoreChanged(Time);

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
