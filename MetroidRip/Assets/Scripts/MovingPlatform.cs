using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject player;
    
    private void OnCollisionEnter2D(Collision2D other) {
         player.transform.parent = transform;
        
    }

    private void OnCollisionExit2D(Collision2D other) {
         player.transform.parent = null;
    }

}
