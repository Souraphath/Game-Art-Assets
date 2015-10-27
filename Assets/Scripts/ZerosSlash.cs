using UnityEngine;
using System.Collections;

public class ZerosSlash : MonoBehaviour {
	public float dmgSlash;
	float speed;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//anim.SetFloat ("Walk", Mathf.Abs (Input.GetAxis ("Horizontal")));
		//		if (Input.GetAxis ("Horizontal") < -0.1f&&Input.GetButtonDown ("Fire1")) {
		//			anim.SetBool ("MoveShoot",true);
		//			transform.localScale=new Vector3(-1,1,1);
		//		}
		//		if (Input.GetAxis ("Horizontal") > 0.1f&&Input.GetButtonDown ("Fire1")) {
		//			anim.SetBool ("MoveShoot",true);
		//			transform.localScale=new Vector3(1,1,1);
		//		}
		if (Input.GetButtonDown ("Fire1"))
			anim.SetBool ("Slash",true);
		if (Input.GetButtonUp ("Fire1"))
			anim.SetBool ("Slash",false);
		
		
	}
}
