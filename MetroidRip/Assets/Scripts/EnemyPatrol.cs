using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private Vector3 m_Velocity = Vector3.zero;
    private float m_MovementSmoothing = .02f;
    //private int range = 8;
    //private Vector2 sightDirection = Vector2.right;
    
    public float patrolSpeed;
    public Rigidbody2D _rigidbody;
    public Transform groundCheck;
    public Transform wallCheck;
    private bool noGround;
    private bool hitWall;
    public LayerMask platformLayer;
    //public GameObject eyes;
    //private bool foundPlayer = false;
    //public Transform player;
   
    void Update()
    {
        noGround = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, platformLayer);
        hitWall = Physics2D.OverlapCircle(wallCheck.position, 0.1f, platformLayer);
        //RaycastHit2D hit = Physics2D.Raycast(eyes.transform.position, sightDirection * range);
        //Debug.DrawRay(eyes.transform.position, sightDirection * range);
        // if (hit.transform.tag == "Player") {
        //     foundPlayer = true;
        // } else {
        //     foundPlayer = false;
        // }
    }

    private void FixedUpdate() {
        // if (foundPlayer) {
        //     Attack();
        // } else {
        //     Patrol();
        // }
        Patrol();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            Destroy(this.gameObject);
        }
    }

    void Patrol() {
        if (noGround || hitWall) {
            Flip();
        }
        Vector3 targetVelocity = new Vector2(patrolSpeed, _rigidbody.velocity.y);
       _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    // void Attack() {
    //     if (player.position.x < transform.position.x && transform.localScale.x > 0) {
    //         Flip();
    //     }
    //     if (player.position.x > transform.position.x && transform.localScale.x < 0) {
    //         Flip();
    //     }
    // }

    void Flip() {
        transform.localScale =  new Vector2(transform.localScale.x * -1, transform.localScale.y);
        patrolSpeed *= -1;
        //sightDirection = -sightDirection;
    }
}
