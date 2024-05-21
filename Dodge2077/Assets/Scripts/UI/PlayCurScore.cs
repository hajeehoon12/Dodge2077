using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayCurScore : MonoBehaviour
{
    public static PlayCurScore instance;
    private float text_score = 9999f;
    private float up_score = 0f;
    public Text _text;
    private bool _SceneChange = false;


    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //if(DataManager.Instance.curScore != null)
        text_score = DataManager.Instance.curScore;
        Debug.Log(text_score);
    }

    // Update is called once per frame
    void Update()
    {
        up_score += text_score * Time.deltaTime * 0.8f;
        if (up_score >= text_score && !_SceneChange)
        {
            _text.text = text_score.ToString("F0");
            StartCoroutine(GoStartScene());

        }
        else if (up_score >= text_score)
        {
            _text.text = text_score.ToString("F0");
        }
        else
        {
            _text.text = up_score.ToString("F0");
        }
    }

    private IEnumerator GoStartScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("StartScene");

    }



}
