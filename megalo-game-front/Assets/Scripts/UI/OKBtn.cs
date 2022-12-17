using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OKBtn : MonoBehaviour
{
    public static int Level;
    [SerializeField] TMP_Dropdown dropdown;
    
    public void OnClick()
    {
        Level = dropdown.value;
        Debug.Log("OKBtn :" + dropdown.value);
    }
    public int GetLevel()
    {
        return Level;
    }
}
