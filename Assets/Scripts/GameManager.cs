using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class GameManager: MonoBehaviour {

	public static Color32 colorBelowMousePointer;
	public static string[] textList = new string[20];
	public static string url = "";
	public static string textUrl = "";
	public static float NumberOfElements = 0;
	public static bool piecewise = false;
	public static bool audio = true;
	public static bool haptic = true;
	public static int piecewiseStep = 0;
	public static int PrevPiecewiseStep = 0;
	public static bool FingerMoving;
	public static Touch touch;
	public static string diagramTitle = "New Diagram";
	public static float timer = 0;

	void Start(){
	}
	// Use this for initialization
	void Awake() {
	}
	void Update(){
		 if(Input.touchCount > 0){ //if there is any touch
            touch = Input.GetTouch(0);
		}
		else if(Time.time-timer>5){
			EasyTTSUtil.StopSpeech ();
		}
	}

	public static void UpdatePieceWiseStep(){
		if (piecewise == true) {
			GameObject[] elementList = GameObject.FindGameObjectsWithTag ("DiagramElement");
			if(piecewiseStep < elementList.Length){
				elementList [piecewiseStep].GetComponent<DiagramElementOBJ> ().enabled = true;
				elementList [piecewiseStep].SetActive (true);
				EasyTTSUtil.StopSpeech ();

				if(piecewiseStep == 0){
				EasyTTSUtil.SpeechAdd (diagramTitle+", Loaded, " + elementList [piecewiseStep].GetComponent<DiagramElementOBJ> ().elementLabel+".");
				}
				else if(elementList [piecewiseStep].GetComponent<DiagramElementOBJ> ().elementLabel!="Label"){
					EasyTTSUtil.SpeechAdd (", Loaded, " + elementList [piecewiseStep].GetComponent<DiagramElementOBJ> ().elementLabel+".");
				}
				piecewiseStep++;
			}
				else{
				EasyTTSUtil.StopSpeech ();
				EasyTTSUtil.SpeechAdd ("All Elements Loaded");
				}	
		}
	}
	public static bool FingerMoved(){
		if(FingerMoving)
			return true;
		else
			return false;
	}

}

//object for us to send - can't just send the above monobehavoir or else its weird
[Serializable] //to make it so we can write this to a file, we need this
class PlayerData {
	public Color32 colorBelowMousePointer;
	public string[] textList;
	public float NumberOfElements;
	public string url;
	public string textUrl;
	public bool piecewise;
	public bool haptic;
	public bool audio;
	public int piecewiseStep;
	public int PrevPiecewiseStep;
	public bool FingerMoving;
	public Touch touch;
}

