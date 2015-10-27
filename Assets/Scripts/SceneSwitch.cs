using UnityEngine;
using System.Collections;

public class SceneSwitch : MonoBehaviour {

    public string sceneName;

    void OnTriggerEnter() {
        Application.LoadLevel(sceneName);
    }
}
