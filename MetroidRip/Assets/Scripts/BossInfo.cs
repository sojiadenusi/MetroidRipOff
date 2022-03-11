using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BossInfo : MonoBehaviour
{
    public TextMeshProUGUI ammoUI;
    // Update is called once per frame
    void Update()
    {
        ammoUI.text = "Boss Health: " + GlobalVariables.bossHealth;
    }
}
