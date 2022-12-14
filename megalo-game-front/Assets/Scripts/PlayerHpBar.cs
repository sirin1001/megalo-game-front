using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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

    public void RecvDamege()
    {
        HP--;
        slider.value = HP;
        if(HP <= 0)
        {
            Destroy(GameObject.Find("Player(Clone)"));
            Debug.Log("Lose");
            GameObject.Find("BattleManager").GetComponent<BattleManager>().SetWin(false);
            SceneManager.LoadScene("ResultScene");
        }
    }

}
