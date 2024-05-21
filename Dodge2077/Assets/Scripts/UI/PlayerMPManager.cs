using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMPManager : MonoBehaviour
{
    [SerializeField] private Slider hpBarSlider = null;
    [SerializeField] private bool Is2P;

    private float PlayerMaxMP;
    private float PlayerCurrentMP;

    private void Start()
    {
        if (DataManager.Instance.is1P)
        {
            if (Is2P) gameObject.SetActive(false);
        }
    }

    void Update()
    {
        
    }

    public void UseMana(float mana)
    {
        PlayerCurrentMP -= mana;
        if (PlayerCurrentMP < 0.0f) PlayerCurrentMP = 0.0f;
        else if (PlayerCurrentMP > PlayerMaxMP) PlayerCurrentMP = PlayerMaxMP;
        SetMPBar();
    }

    public void SetMPBar()
    {
        hpBarSlider.value = PlayerCurrentMP / PlayerMaxMP;
    }

    public void ChangeMaxMP(float newMaxMP)
    {
        PlayerMaxMP = newMaxMP;

        Debug.Log("CurrentMana: " + PlayerCurrentMP); Debug.Log("MaxMana: " + PlayerMaxMP);
    }
    public void ChangeCurrentMP(float newCurrentMP)
    {
        PlayerCurrentMP = newCurrentMP;

        Debug.Log("CurrentMana: " + PlayerCurrentMP); Debug.Log("MaxMana: " + PlayerMaxMP);
    }
}
