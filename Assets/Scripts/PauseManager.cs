using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    public GameObject pnlPause;
    private bool isPaused;

    void Start() {
        isPaused = false;
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            ChangePauseStatus();
        }
    }

    public void ChangePauseStatus() {
        isPaused = !isPaused;
        UpdateGamePause();
    }

    void UpdateGamePause() {
        if (isPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        pnlPause.SetActive(isPaused);
    }
}
