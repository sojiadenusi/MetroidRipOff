using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Animator animator;
	[SerializeField] private LayerMask platformLayerMask;
	private Vector3 m_Velocity = Vector3.zero;
    private float m_MovementSmoothing = .02f;
	public float speed = 10f;
	public float jumpForce = 20f;
	private bool jump = false;
	private int numOfJumps = 0;
	private float horizontalMovement;
	private Rigidbody2D _rigidbody;
	private BoxCollider2D player_collider;
	private bool grounded = true;
	[HideInInspector] public bool flipped = false;
	private GameObject floatingPlatform;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
		player_collider = GetComponent<BoxCollider2D>();
		_rigidbody.gravityScale = 3;
		//animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
		grounded = isGrounded();
		if (grounded) {
			numOfJumps = 0;
		}
		if (!grounded && !jump && numOfJumps == 0) {
			numOfJumps++;
		}

        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;
		animator.SetFloat("speed", Mathf.Abs(horizontalMovement));

		if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) ) {
			jump = true;
		}
		Flip();
    }
	void FixedUpdate() {
		Vector3 targetVelocity = new Vector2(horizontalMovement, _rigidbody.velocity.y);
		_rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

		if (jump && numOfJumps < 2) {
			if (numOfJumps == 1) {
				jumpForce = jumpForce - 3;
				_rigidbody.velocity = Vector2.up * jumpForce;
				jumpForce = jumpForce + 3;
			} else {
				_rigidbody.velocity = Vector2.up * jumpForce;
			}
			numOfJumps++;
		}
		jump = false;
	}

	private bool isGrounded()
    {
        float extraHeight = .1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(player_collider.bounds.center, player_collider.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);
		if (raycastHit.collider != null && Input.GetKeyDown(KeyCode.S)) {
			if (raycastHit.collider.GetComponent<PlatformEffector2D>() != null) {
				raycastHit.collider.GetComponent<PlatformEffector2D>().rotationalOffset = 180;
				floatingPlatform = raycastHit.collider.gameObject;
			}
		}

		if (raycastHit.collider == null) {
			if (floatingPlatform != null && floatingPlatform.GetComponent<PlatformEffector2D>() != null)
				floatingPlatform.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
		}
		
		return raycastHit.collider != null;
    }

	private void Flip() {
		if (horizontalMovement > 0 && transform.localScale.x < 0 || horizontalMovement < 0 && transform.localScale.x > 0) {
			transform.localScale *= new Vector2(-1,1);
			flipped = !flipped;
		}
	}
}