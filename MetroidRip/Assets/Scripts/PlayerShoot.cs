using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;
    public Transform gun;
    private bool canShoot = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canShoot && GlobalVariables.ammo > 0)
        {
            shoot();
        }
    }

    void shoot() {
        if (GetComponent<PlayerMovement>().flipped == false) {
            Instantiate(projectile, gun.position, Quaternion.identity);
        }
        else {
            Instantiate(projectile, gun.position, Quaternion.identity);
        }
        GlobalVariables.ammo -= 1;
        canShoot = false;
        StartCoroutine(coolDown());
    }

    IEnumerator coolDown() {
        yield return new WaitForSeconds(1);
        canShoot = true;
        yield return null;
    }
}