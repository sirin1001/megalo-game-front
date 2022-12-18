using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    int MaxHp = 10;
    int Hp;
    void Start()
    {
        
    }

    public void GetObject()
    {
        Hp = GameObject.Find("Canvas").transform.Find("Hpbar").GetComponent<EnemyHpBar>().Hp;
        Hp = MaxHp;
        slider.value = MaxHp;
    }

    public void Damage()
    {
        Hp--;
        slider.value = Hp;
        
        Debug.Log("[Debug] HP " + Hp);
        if (Hp <= 0)
        {
            Debug.Log("[Debug] if Hp <= 0");
            GameObject.Find("Scarlet").GetComponent<Scarlet>().Dead();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            Damage();

            
        }
    }
}
