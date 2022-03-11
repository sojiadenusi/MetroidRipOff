using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacles : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        this.enabled = false;
        GlobalVariables.bossTentacles -= 1;
    }
}
