using UnityEngine;
using System.Collections;

public class ZerosShoot : MonoBehaviour {
	public float dmgpershot;
	float speed;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire2"))
			anim.SetBool ("Shoot",true);
		if (Input.GetButtonUp ("Fire2"))
			anim.SetBool ("Shoot",false);


	}
}
