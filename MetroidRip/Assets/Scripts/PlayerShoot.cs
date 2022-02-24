using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;
    private bool canShoot = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canShoot)
        {
            shoot();
        }
    }

    void shoot() {
        if (GetComponent<PlayerMovement>().flipped == false) {
            Instantiate(projectile, transform.position + new Vector3(1.5f, 0, 0), Quaternion.identity);
        }
        else {
            Instantiate(projectile, transform.position + new Vector3(-1.5f, 0, 0), Quaternion.identity);
        }
        canShoot = false;
        StartCoroutine(coolDown());
    }

    IEnumerator coolDown() {
        yield return new WaitForSeconds(1);
        canShoot = true;
        yield return null;
    }
}