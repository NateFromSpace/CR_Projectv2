using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatisGround;
	private bool grounded;

	private bool doubleJumped;

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatisGround);
		}
	
	// Update is called once per frame
	void Update () {

		if (grounded)
						doubleJumped = false;
		anim.SetBool ("Grounded", grounded);

		if (Input.GetKeyDown (KeyCode.Space) && grounded) 
		{
			//rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpHeight); See Line 62
			Jump ();
		}

		if (Input.GetKeyDown (KeyCode.Space) && !doubleJumped && !grounded) 
		{
			//rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpHeight); 62
			Jump ();
			doubleJumped = true;


		}


		if (Input.GetKey(KeyCode.D)) 
		{
			rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
		}

		if (Input.GetKey(KeyCode.A)) 
		{
			rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);
		}

		anim.SetFloat ("Speed", Mathf.Abs(rigidbody2D.velocity.x));

		if (rigidbody2D.velocity.x > 0)
						transform.localScale = new Vector3 (1f, 1f, 1f);
				else if (rigidbody2D.velocity.x < 0)
						transform.localScale = new Vector3 (-1f, 1f, 1f);


	
	}

	public void Jump()
	{
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpHeight);
	}

}
