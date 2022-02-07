using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int cardPoint = 0;
        int spPoint = 0;
        int costOver = 0;
        int score = 0;

        Cost cost = GameObject.Find("MaxCost").GetComponent<Cost>();

        Text situationText = GameObject.Find("SituationText").GetComponent<Text>();
        Text sWord = GameObject.Find("S Word").GetComponent<Text>();
        Text vWord = GameObject.Find("V Word").GetComponent<Text>();

        string[] schoolBonus = { "部活で", "プールで" };
        string[] sBonus = { "睡眠中で", "道路で", "飼い犬が", "飼い猫が", "推しが" };
        string[] vBonus = { "配信する", "修行する" };

        cardPoint = (12 - cost.currentCost) * 100 + 1000;

        if(situationText.text == "学校")
        {
            int school = Array.IndexOf(schoolBonus, sWord.text);
            if(school >= 0)
            {
                spPoint += 100;
            }
        }
        int sB = Array.IndexOf(sBonus, sWord.text);
        if(sB >= 0)
        {
            spPoint += 100;
        }
        int vB = Array.IndexOf(vBonus, vWord.text);
        if (vB >= 0)
        {
            spPoint += 100;
        }

        costOver = cost.currentCost - cost.maxCost;
        if(costOver > 0)
        {
            costOver *= 500;
        }
        else
        {
            costOver = 0;
        }

        score = 5000 + cardPoint + spPoint - costOver;

        transform.Find("CardPoint").GetComponent<Text>().text = cardPoint.ToString();
        transform.Find("SPPoint").GetComponent<Text>().text = spPoint.ToString();
        transform.Find("CostOver").GetComponent<Text>().text = costOver.ToString();
        transform.Find("Score").GetComponent<Text>().text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
