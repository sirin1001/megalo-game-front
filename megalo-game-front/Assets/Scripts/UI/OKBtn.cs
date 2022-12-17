using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OKBtn : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown;
    
    public void OnClick()
    {
        Debug.Log("OKBtn :" + dropdown.value);
    }
}
