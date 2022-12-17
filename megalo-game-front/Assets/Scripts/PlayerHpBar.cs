using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerHpBar : MonoBehaviour
{

    private Slider slider;
    private float MAXHP = 10;
    private int HP;

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("PlayerHpBar").GetComponent<Slider>();
        HP = (int)MAXHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecvDamege()
    {
        HP --;
        slider.value = HP / MAXHP;
    }

}
