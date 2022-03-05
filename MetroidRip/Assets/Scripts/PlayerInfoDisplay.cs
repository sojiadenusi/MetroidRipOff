using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInfoDisplay : MonoBehaviour
{
    public TextMeshProUGUI ammoUI;
    void Update()
    {
        ammoUI.text = "Health: " + GlobalVariables.health + "\n" + "Ammo: " + GlobalVariables.ammo;
    }
}
