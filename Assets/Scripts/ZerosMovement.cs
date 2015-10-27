using UnityEngine;
using System.Collections;

public class ZerosMovement : MonoBehaviour {
	public float maxspeed;
	public float speed;
	private Animator anim;
	Rigidbody2D rb;
	Vector2 playerVelocity;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		playerVelocity = Vector2.zero;
	}
	void Update()
	{
		anim.SetFloat ("Walk", Mathf.Abs (Input.GetAxis ("Horizontal")));
		playerVelocity.x = Input.GetAxis ("Horizontal") * maxspeed;
		if (Input.GetAxis ("Horizontal") < -0.1f&&!Input.GetButtonDown ("Fire1")) {
			transform.localScale=new Vector3(-1,1,1);
		}
		if (Input.GetAxis ("Horizontal") > 0.1f&&!Input.GetButtonDown ("Fire1")) {
			transform.localScale=new Vector3(1,1,1);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			rb.AddForce(transform.up*1000);
			anim.SetTrigger("Jump");
		}
		if (Input.GetAxis ("Horizontal") != 0 && Input.GetKeyDown (KeyCode.LeftShift)) {
			//playerVelocity.x = Input.GetAxis ("Horizontal") * maxspeed;
			rb.AddForce(transform.right*1000);
			anim.SetTrigger("Dash");
		}
		rb.velocity = playerVelocity;
	}
	// Update is called once per frame
//	void FixedUpdate () {
//		//float move = Input.GetAxis ("Horizontal");
//		//rb.AddForce ((Vector2.right *speed)* move);
//		if (rb.velocity.x > maxspeed) {
//			rb.velocity=new Vector2(maxspeed,0);
//		}
//		if (rb.velocity.x < -maxspeed) {
//			rb.velocity=new Vector2(-maxspeed,0);
//		}
//
//
//	}
}
