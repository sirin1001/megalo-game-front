using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public GameObject score_obj = null;
    public int score_num = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Hit()
    {
        score_num += 1000;
        Text score_text = score_obj.GetComponent<Text>();
        score_text.text = "Score" + score_num;

    }
}
