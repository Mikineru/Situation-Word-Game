using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    GameObject maxCost;

    // Start is called before the first frame update
    void Start()
    {
        string[][][] situation = new string[3][][];

        situation[0] = new string[6][];

        situation[0][0] = new string[0];
        situation[0][1] = new string[1];
        situation[0][2] = new string[5];
        situation[0][3] = new string[3];
        situation[0][4] = new string[1];
        situation[0][5] = new string[0];

        situation[0][1][0] = "レストランで";
        situation[0][2][0] = "自宅で";
        situation[0][2][1] = "睡眠中で";
        situation[0][2][2] = "プールで";
        situation[0][2][3] = "出張先で";
        situation[0][2][4] = "道路で";
        situation[0][3][0] = "部活で";
        situation[0][3][1] = "コンビニで";
        situation[0][3][2] = "風呂場で";
        situation[0][4][0] = "授業で";

        situation[1] = new string[6][];

        situation[1][0] = new string[2];
        situation[1][1] = new string[1];
        situation[1][2] = new string[1];
        situation[1][3] = new string[4];
        situation[1][4] = new string[3];
        situation[1][5] = new string[1];

        situation[1][0][0] = "飼い犬が";
        situation[1][0][1] = "飼い猫が";
        situation[1][1][0] = "推しが";
        situation[1][2][0] = "娘が";
        situation[1][3][0] = "先生が";
        situation[1][3][1] = "友達が";
        situation[1][3][2] = "彼氏が";
        situation[1][3][3] = "彼女が";
        situation[1][4][0] = "僕が";
        situation[1][4][1] = "私が";
        situation[1][4][2] = "親が";
        situation[1][5][0] = "家族が";

        situation[2] = new string[6][];

        situation[2][0] = new string[1];
        situation[2][1] = new string[2];
        situation[2][2] = new string[0];
        situation[2][3] = new string[1];
        situation[2][4] = new string[3];
        situation[2][5] = new string[1];

        situation[2][0][0] = "修行する";
        situation[2][1][0] = "配信する";
        situation[2][1][1] = "宿題を忘れた";
        situation[2][3][0] = "逮捕された";
        situation[2][4][0] = "ケガした";
        situation[2][4][1] = "病気になった";
        situation[2][4][2] = "気持ち悪い";
        situation[2][5][0] = "死んだ";

        var listWord = new HashSet<string>();
        var listGroup = new List<string>();

        while (listWord.Count < 5 || !listGroup.Contains("述") || !(listGroup.Contains("場") || listGroup.Contains("主")))
        {
            listWord.Clear();
            listGroup.Clear();

            for (int ca = 1; ca < 6; ca++)
            {
                GameObject card = GameObject.Find($"Card{ca}");
                Text word = card.transform.Find("Word").gameObject.GetComponent<Text>();
                Text group = card.transform.Find("Group").gameObject.GetComponent<Text>();
                Text cost = card.transform.Find("Cost").gameObject.GetComponent<Text>();

                int i = (Random.Range(0, situation.Length));
                int j = (Random.Range(0, situation[i].Length));
                int k = (Random.Range(0, situation[i][j].Length));
                while (situation[i][j].Length == 0)
                {
                    i = (Random.Range(0, situation.Length));
                    j = (Random.Range(0, situation[i].Length));
                    k = (Random.Range(0, situation[i][j].Length));
                }
                Debug.Log(situation[i][j][k]);

                word.text = situation[i][j][k];
                switch (i)
                {
                    case 0:
                        group.text = "場";
                        break;
                    case 1:
                        group.text = "主";
                        break;
                    case 2:
                        group.text = "述";
                        break;
                }
                cost.text = $"{j + 1}";

                listWord.Add(word.text);
                listGroup.Add(group.text);
            }

            Debug.Log(listWord.Count);
            Debug.Log(listGroup.Contains("述"));
            Debug.Log(listGroup.Contains("場") || listGroup.Contains("主"));
        }

        maxCost = GameObject.Find("MaxCost");
    }

    int sCost = 0;
    int vCost = 0;

    // Update is called once per frame
    void Update()
    {
        maxCost.GetComponent<Cost>().currentCost = sCost + vCost;
    }


    public void OnButtonClick()
    {
        Text sWord = GameObject.Find("S Word").GetComponent<Text>();
        Text vWord = GameObject.Find("V Word").GetComponent<Text>();

        EventSystem eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        Text groupD = eventSystem.currentSelectedGameObject.transform.Find("Group").gameObject.GetComponent<Text>();
        Text wordD = eventSystem.currentSelectedGameObject.transform.Find("Word").gameObject.GetComponent<Text>();
        Text costD = eventSystem.currentSelectedGameObject.transform.Find("Cost").gameObject.GetComponent<Text>();

        if (groupD.text == "場" || groupD.text == "主")
        {
            sWord.text = wordD.text;
            sCost = int.Parse(costD.text);
        }
        else if (groupD.text == "述")
        {
            vWord.text = wordD.text;
            vCost = int.Parse(costD.text);
        }
    }
}
