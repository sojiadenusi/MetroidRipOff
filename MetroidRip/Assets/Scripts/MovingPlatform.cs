using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject player;
    

    private void OnTriggerEnter2D(Collider2D other) {
        
        player.transform.parent = transform;
        //player.transform.localScale = new Vector3(1,1,1);

    }

    private void OnTriggerExit2D(Collider2D other) {
        
        player.transform.parent = null;
    }

}
