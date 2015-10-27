using UnityEngine;
using System.Collections;

public class OpenDoorScript : MonoBehaviour {

    public Animator doorAnim;
    public Animator buttonAnim;

    void OnTriggerEnter(Collider other) {
        doorAnim.SetTrigger("ButtonPressed");
        buttonAnim.SetTrigger("ButtonPressed");
    }
}
