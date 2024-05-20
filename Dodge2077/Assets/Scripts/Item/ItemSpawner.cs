using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField] private GameObject powerUP;        //30%
    [SerializeField] private GameObject speedUP;        //30%
    [SerializeField] private GameObject addSkillPoint;  //15%
    [SerializeField] private GameObject shield;         //10%
    [SerializeField] private GameObject addTriangle;    //10%
    [SerializeField] private GameObject homing;         //5%

    private int powerUPPer;
    private int speedUPPer;
    private int addSkillPointPer;
    private int shieldPer;
    private int addTrianglePer;
    private int homingPer;

    void Awake()
    {
        powerUPPer = 30;
        speedUPPer = powerUPPer + 30;
        addSkillPointPer = speedUPPer + 15;
        shieldPer = addSkillPointPer + 10;
        addTrianglePer = shieldPer + 10;
        homingPer = addTrianglePer + 5;
}

    void Start()
    {
        StartCoroutine(SpawnItem());
    }

    void Update()
    {
        
    }

    private IEnumerator SpawnItem()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);

            int itemType = Random.Range(1, 101);
            float randX = Random.Range(-2.5f, 2.5f);
            Vector2 spawnLoaction = new Vector3(randX, 5.0f, 0);

            //아직 아이템을 2개만 구현해서 다 구현하면 이 코드를 쓸 것
            //if (itemType <= powerUPPer) Instantiate(powerUP, new Vector3(0, 0, 0), Quaternion.identity);
            //else if (itemType <= speedUPPer) Instantiate(speedUP, new Vector3(0, 0, 0), Quaternion.identity);
            //else if (itemType <= addSkillPointPer) Instantiate(addSkillPoint, new Vector3(0, 0, 0), Quaternion.identity);
            //else if (itemType <= shieldPer) Instantiate(shield, new Vector3(0, 0, 0), Quaternion.identity);
            //else if (itemType <= addTrianglePer) Instantiate(addTriangle, new Vector3(0, 0, 0), Quaternion.identity);
            //else if(itemType <= homingPer) Instantiate(homing, new Vector3(0, 0, 0), Quaternion.identity);

            if (itemType <= 50) Instantiate(powerUP, spawnLoaction, Quaternion.identity);
            else Instantiate(speedUP, spawnLoaction, Quaternion.identity);
        }
    }
}
