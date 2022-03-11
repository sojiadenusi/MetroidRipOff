using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryShooter : MonoBehaviour
{
    private int range = 8;
    private Vector2 sightDirection = Vector2.right;
    public Rigidbody2D _rigidbody;
    public GameObject eyes;
    private bool foundPlayer = false;
    public GameObject bullet;
    private bool canShoot = true;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(eyes.transform.position, -sightDirection * range);
        if (hit.collider != null) {
            if (hit.transform.tag == "Player" || hit.transform.tag == "MonsterBullet") {
                foundPlayer = true;
            } else {
                foundPlayer = false;
            }
        }
    }
    private void FixedUpdate() {
        if (foundPlayer) {
            print("found");
            Attack();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            Destroy(this.gameObject);
        }
    }
    void Attack() {
        _rigidbody.velocity = Vector2.zero;

        if (canShoot) {
            Instantiate(bullet, eyes.transform.position + new Vector3(0, .85f), Quaternion.identity);
            canShoot = false;
            StartCoroutine(shootCD());
        }
    }
    IEnumerator shootCD() {
        yield return new WaitForSeconds(0.8f);
        canShoot = true;
        yield return null;
    }
}
