using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerHpBar : MonoBehaviour
{

    [SerializeField] Slider slider;
    private float MAXHP = 10;
    private int HP;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = MAXHP;
        HP = (int)MAXHP;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            RecvDamege();
        }
    }

    public void RecvDamege()
    {
        Debug.Log("RecvDamege");
        HP --;
        slider.value = HP;
        if(HP <= 0)
        {
            Destroy(GameObject.Find("Player(Clone)"));
            Debug.Log("Lose");
            GameObject.Find("BattleManager").GetComponent< BattleManager >().SetWin(false);
        }
    }

}
