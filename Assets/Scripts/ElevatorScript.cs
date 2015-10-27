using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour
{
    public float timeToLiftStart = 3f;
    public float liftSpeed = 0.01f;

    public float liftTime;

    private GameObject player;

    private bool playerInLift;
    private float timer;

    private bool isDown;

	void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
        isDown = true;
	}
	
	void OnTriggerEnter(Collider other){
        if (other.gameObject == player)
            playerInLift = true;
	}

    void OnTriggerExit(Collider other) {
        if (other.gameObject == player) {
            playerInLift = false;
        }
    }

    void Update() {
        if (playerInLift)
        {
            LiftActivation();
        }

        if (timer >= timeToLiftStart && !playerInLift)
        {
            player.transform.parent = null;
            isDown = !isDown;
            timer = 0;
        }

    }

    void LiftActivation() {
        timer += Time.deltaTime;
        player.transform.parent = transform;
        if (timer <= timeToLiftStart) {
            if (isDown)
            {
                transform.Translate(Vector3.up * liftSpeed * Time.deltaTime);
            }
            else {
                transform.Translate(-1 * Vector3.up * liftSpeed * Time.deltaTime);
            }
        }
        
    }

}