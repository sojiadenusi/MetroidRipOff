using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BossInfo : MonoBehaviour
{
    public TextMeshProUGUI ammoUI;
    void Update()
    {
        ammoUI.text = "Boss Health: " + GlobalVariables.bossHealth;
    }
}
