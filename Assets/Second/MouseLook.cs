using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{

    public float lookSensitivity = 5f;
    [HideInInspector]
    public float currentTargetCameraAngle = 60f;

    [HideInInspector]
    public float xRot, yRot;
    [HideInInspector]
    public float curYRot, curXRot;
    [HideInInspector]
    public float yRotV, xRotV;
    [HideInInspector]
    public float lookSmoothDamp = 0.2f; // bigger is smoother

    [HideInInspector]
    public float currentAimRatio = 1.0f;

    float headBobSpeed = 1f;
    public float headBobStepCounter;
    Vector3 parentLastPos;

    void Awake()
    {
        parentLastPos = transform.parent.position;
    }

    void FixedUpdate()
    {
        if (transform.parent.GetComponent<PlayerMove>().cc.isGrounded)
        {
            headBobStepCounter += Vector3.Distance(parentLastPos, transform.parent.position) * headBobSpeed;
        }
        transform.localPosition = new Vector3(0, 2f, -2.5f);
        parentLastPos = transform.parent.position;

        yRot += Input.GetAxis("Mouse X") * lookSensitivity * currentAimRatio;
        xRot -= Input.GetAxis("Mouse Y") * lookSensitivity * currentAimRatio;

        xRot = Mathf.Clamp(xRot, -30, 30);

        curXRot = Mathf.SmoothDamp(curXRot, xRot, ref xRotV, lookSmoothDamp);
        curYRot = Mathf.SmoothDamp(curYRot, yRot, ref yRotV, lookSmoothDamp);

        transform.rotation = Quaternion.Euler(curXRot, curYRot, 0);
    }
}
