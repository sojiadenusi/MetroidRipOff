using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;
    public Transform gun;
    private bool canShoot = true;
    public AudioClip bulletSound;
    AudioSource _audioSource;
    

    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot && GlobalVariables.ammo > 0)
        {
            shoot();
            _audioSource.PlayOneShot(bulletSound);
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