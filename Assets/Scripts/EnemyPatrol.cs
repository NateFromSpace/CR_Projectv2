using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatisWall;
	private bool hittingWall;


	private bool notAtEdge;
	public Transform edgeCheck;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatisWall);
		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatisWall);


		if (hittingWall || !notAtEdge)
						moveRight = !moveRight;

		if (moveRight) {

			transform.localScale = new Vector3 (-1f, 1f, 1f);
						rigidbody2D.velocity = new Vector2 (moveSpeed, rigidbody2D.velocity.y);
				} else {
							transform.localScale = new Vector3 (1f, 1f, 1f);
							rigidbody2D.velocity = new Vector2 (-moveSpeed, rigidbody2D.velocity.y);

					}
	
	}
}
