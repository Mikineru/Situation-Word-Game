using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cost : MonoBehaviour
{
    Text text;
    GameObject dice1;
    GameObject dice2;
    int cost1;
    int cost2;
    int maxCost;
    public bool decideCost = false;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        dice1 = GameObject.Find("Dice1");
        dice2 = GameObject.Find("Dice2");
    }

    // Update is called once per frame
    void Update()
    {
        if (!decideCost)
        {
            if (dice1.GetComponent<Dice>().isSleep && dice2.GetComponent<Dice>().isSleep)
            {
                cost1 = dice1.GetComponent<Dice>().topIndex;
                cost2 = dice2.GetComponent<Dice>().topIndex;
                maxCost = cost1 + cost2 + 2;
                text.text = "コスト：0 / " + maxCost;
                dice1.SetActive(false);
                dice2.SetActive(false);
                decideCost = true;
            }
        }
    }
}
