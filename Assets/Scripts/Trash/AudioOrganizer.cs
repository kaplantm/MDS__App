//using UnityEngine;
//using System.Collections;
//
//public class AudioOrganizer : MonoBehaviour {
//
//	string toSpeak = "";
//	int thisItemIndex = 0;
//	int currentIndex;
//	int prevIndex;
//	Color prevColor = Color.clear;
//	GameObject[] taggedItems; 
//
//	void Start(){
//		taggedItems = GameObject.FindGameObjectsWithTag("DiagramElement");
//		EasyTTSUtil.Initialize (EasyTTSUtil.UnitedStates);
//	}
//		
//	
//	// Update is called once per frame
//	void Update () {
//		
////		print (GameManager.colorBelowMousePointer+"   "+GameManager.colorIndex[0]);
////		print(IterateThroughColors());
//
//		prevIndex = currentIndex;
//		currentIndex = IterateThroughColors ();
//
//		if (currentIndex != -1 && currentIndex != prevIndex && prevColor == Color.clear) {
//			EasyTTSUtil.StopSpeech ();
//			toSpeak = GameManager.labelIndex [currentIndex];
//			EasyTTSUtil.SpeechAdd (toSpeak); 
//			Handheld.Vibrate ();
//			print (toSpeak);
//		}
////		else {
////			EasyTTSUtil.StopSpeech ();
////			hasSpoken = false;
////			print ("yo2");
////		}
//
//		prevColor = GameManager.colorBelowMousePointer;
//	}
//		
//	int IterateThroughColors(){
//		for (int i = 0; i < GameManager.colorIndex.Length; i++) {
//			if ((GameManager.colorBelowMousePointer.r + .005 >= GameManager.colorIndex [i].r && GameManager.colorBelowMousePointer.r - .005 <= GameManager.colorIndex [i].r) &&
//			    (GameManager.colorBelowMousePointer.g + .005 >= GameManager.colorIndex [i].g && GameManager.colorBelowMousePointer.g - .005 <= GameManager.colorIndex [i].g) &&
//			    (GameManager.colorBelowMousePointer.b + .005 >= GameManager.colorIndex [i].b && GameManager.colorBelowMousePointer.b - .005 <= GameManager.colorIndex [i].b)) {
//					return i;
//			} 
//		}
//		return -1;
//	}
//
//	void OnApplicationQuit() 
//	{
//		EasyTTSUtil.Stop ();
//	}
//}
