using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;
    public GameObject cameraObject;
    CameraScript cameraScript;

    Animator anim;

    public CharacterController cc;

    float forwardSpeed;
    float sideSpeed;
    float verticalVelocity;
    float jumpSpeed = 7.9f;

    void Start()
    {
        //Cursor.visible = false;
        cc = GetComponent<CharacterController>();
        cameraScript = cameraObject.GetComponent<CameraScript>();
        verticalVelocity = 0f;
        anim = GetComponent<Animator>();
    }
    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0, cameraObject.GetComponent<CameraScript>().curYRot, 0);
        bool in2DMode = cameraScript.in2DMode;
        // movement
        sideSpeed = Input.GetAxis("Horizontal") * moveSpeed;

        if (in2DMode) {
            forwardSpeed = 0;
            Vector3 curPos = transform.position;
            Vector3 newPos = curPos - new Vector3(0, 0, 7 + curPos.z);
            transform.position = newPos;
        }
        else
            forwardSpeed = Input.GetAxis("Vertical") * moveSpeed;

        if(!cc.isGrounded)
            verticalVelocity += Physics.gravity.y * 1.5f * Time.deltaTime;

        if (cc.isGrounded) {
			anim.SetBool("Jump",false);
		}

        if (cc.isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = jumpSpeed;
            anim.SetBool("Jump",true);
        }

        Vector3 velocity = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
        velocity = transform.rotation * velocity;
        if(sideSpeed != 0)
            anim.SetFloat("Walk", Mathf.Abs(sideSpeed));
        if(forwardSpeed != 0)
            anim.SetFloat("Walk", Mathf.Abs(forwardSpeed));

        cc.Move(velocity * Time.deltaTime);
		if (Input.GetAxis ("Horizontal") < -0.1f) {
			transform.localScale=new Vector3(-3,3,3);
		}
		if (Input.GetAxis ("Horizontal") > 0.1f) {
			transform.localScale=new Vector3(3,3,3);
		}
		if(Input.GetButtonDown("Fire1"))
			anim.SetBool("Slash",true);
		if(Input.GetButtonDown("Fire2"))
			anim.SetBool("Shoot",true);
		if (Input.GetButtonUp ("Fire1"))
			anim.SetBool ("Slash", false);
		if (Input.GetButtonUp ("Fire2"))
			anim.SetBool ("Shoot", false);
		if ( Input.GetKeyDown (KeyCode.LeftShift)&&cc.isGrounded) {
			cc.Move(velocity * Time.deltaTime*5);
			anim.SetTrigger("Dash");
		}

        if(transform.position.y <= -20) {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
