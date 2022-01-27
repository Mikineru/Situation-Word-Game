using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject canvas;
    GameObject situation;
    Animator animator;
    GameObject cost;
    GameObject dice;
    GameObject dice1;
    GameObject dice2;
    bool isEnd = false;
    GameObject sentence;
    GameObject card;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        situation = canvas.transform.Find("Situation").gameObject;
        animator = situation.GetComponent<Animator>();
        cost = canvas.transform.Find("Cost").gameObject;
        dice = GameObject.Find("Dice");
        dice1 = dice.transform.Find("Dice1").gameObject;
        dice2 = dice.transform.Find("Dice2").gameObject;
        sentence = canvas.transform.Find("Sentence").gameObject;
        card = canvas.transform.Find("Card").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isEnd && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            dice1.SetActive(true);
            dice2.SetActive(true);
            cost.SetActive(true);
            isEnd = true;
        }

        if (cost.GetComponent<Cost>().decideCost)
        {
            sentence.SetActive(true);
            card.SetActive(true);
        }
    }
}
