using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacles : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        this.gameObject.SetActive(false);
        GlobalVariables.bossTentacles -= 1;
    }
}
