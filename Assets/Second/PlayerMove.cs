using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public GameObject cameraObject;
    public float moveSpeed = 5f;
    public CharacterController cc;
    Animator ac;
    float verticalVelocity = 0;
    float jumpSpeed = 5f;

    void Awake() {
        cc = GetComponent<CharacterController>();
        ac = GetComponent<Animator>();
    }

    void LateUpdate() {
        float forwardSpeed = Input.GetAxisRaw("Vertical") * moveSpeed;
        float sideSpeed = Input.GetAxisRaw("Horizontal") * moveSpeed;

        verticalVelocity += Physics.gravity.y * Time.deltaTime;
        if (cc.isGrounded)
            verticalVelocity = Physics.gravity.y;

        if (cc.isGrounded && Input.GetButtonDown("Jump"))
        {
            ac.SetTrigger("jump");
            verticalVelocity = jumpSpeed;
        }

        bool walking = (forwardSpeed != 0 || sideSpeed != 0);
        if (Input.GetButton("Run") && walking) {
            ac.SetBool("running", true);
            forwardSpeed *= 3.0f;
        }
        else
        {
            ac.SetBool("walking", walking);
            ac.SetBool("running", false);
        }

        Vector3 velocity = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

        transform.rotation = Quaternion.Euler(0, cameraObject.GetComponent<MouseLook>().curYRot, 0);
        velocity = transform.rotation * velocity;

        cc.Move(velocity * Time.deltaTime);
    }
}
