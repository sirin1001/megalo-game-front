using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    int MaxHp = 100;
    int Hp;
    void Start()
    {
        Hp = MaxHp;
        slider.value = MaxHp;
    }

    public void Damage()
    {
        Hp--;
        slider.value = Hp;
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            Debug.Log("[Debug]Damage!");
            Damage();
        }
    }
}
