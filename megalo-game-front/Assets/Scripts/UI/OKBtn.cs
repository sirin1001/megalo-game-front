using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class OKBtn : MonoBehaviour
{
    public static int Level;
    [SerializeField] TMP_Dropdown dropdown;
    
    public void OnClick()
    {
        Level = dropdown.value;
        Debug.Log("OKBtn :" + dropdown.value);
        SceneManager.LoadScene("MainScene");

    }
    public int GetLevel()
    {
        return Level;
    }
}
