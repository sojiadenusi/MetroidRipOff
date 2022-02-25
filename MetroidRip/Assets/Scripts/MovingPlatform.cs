using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject player;
    

    private void OnTriggerEnter(Collider other) {
        player.transform.parent = transform;
        //player.transform.localScale = new Vector3(1,1,1);

    }

    private void OnTriggerExit(Collider other) {
        player.transform.parent = null;
    }

}
