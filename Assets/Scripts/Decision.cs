using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Decision : MonoBehaviour
{
    Text sWord;
    Text vWord;
    GameObject card;

    // Start is called before the first frame update
    void Start()
    {
        sWord = GameObject.Find("S Word").GetComponent<Text>();
        vWord = GameObject.Find("V Word").GetComponent<Text>();
        card = GameObject.Find("Card");
    }

    // Update is called once per frame
    void Update()
    {
        if(sWord.text != "" && vWord.text != "")
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
