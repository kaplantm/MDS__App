using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTapDetection : MonoBehaviour {
float currentMouseDownTime;
float PrevMouseDownTime = -1;
float touchDuration = .5f;
public AudioSource audio;

public GameObject panel;

    void Update() {
        if (GameManager.piecewise == true) {
		if(Input.GetMouseButtonDown(0) || GameManager.touch.phase == TouchPhase.Began){
			currentMouseDownTime = Time.time;

			if(PrevMouseDownTime != -1 && currentMouseDownTime < PrevMouseDownTime + touchDuration){
				GameManager.UpdatePieceWiseStep();
                audio.Play();
				GameManager.FingerMoving = false;
			}
			else if(Input.GetMouseButtonDown(0)){
				GameManager.FingerMoving = true;
			}

			PrevMouseDownTime = currentMouseDownTime;
		}
        }
	}
}
