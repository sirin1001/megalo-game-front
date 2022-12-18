using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResult : MonoBehaviour
{
    Text text;
    void Start()
    {
        if(BattleManager.isWin)
        {
            gameObject.GetComponent<Text>().text = "Win!!";
        }
        else
        {
            gameObject.GetComponent<Text>().text = "Lose...";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
