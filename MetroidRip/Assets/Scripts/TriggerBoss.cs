using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TriggerBoss : MonoBehaviour
{
    public GameObject ammoUI;

    private void Start() {
        ammoUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        ammoUI.SetActive(true);
    }
}
