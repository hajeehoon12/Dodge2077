using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteHyuk : MonoBehaviour
{
    // Start is called before the first frame update

    private int patternNum = 0;
    public GameObject Meteor; // skill object

 

    private void Start()
    {
        Meteor.SetActive(false);   
    }


    public void CallWhite()
    {

        switch (patternNum)
        {
            case 0:
                MeteorOn(); // Call Meteor Skill
                Invoke("MeteorOff", 3f); // Call Skill Off after 3sec
                break;
            case 1:
                break;
            default:
                break;
        
        
        
        
        
        }



        patternNum++;
    }

    private void MeteorOn()
    {
        Meteor.SetActive(true);
    }
    private void MeteorOff()
    {
        Meteor.SetActive(false);
    }




}
