using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Situation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text text = GetComponent<Text>();
        int probability = Random.Range(0, 2);
        Debug.Log(probability);
        if(probability == 0)
        {
            text.text = "学校";
        }
        else
        {
            text.text = "職場";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
