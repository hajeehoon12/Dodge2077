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
        DataManager.Instance.isHighScoreChanged(Time);
        AudioManager.instance.PlayBGM("Victory");
        SceneManager.LoadScene("StartScene");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
