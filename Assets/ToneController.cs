//using UnityEngine;
//using System.Collections;
//
//public class ToneController : MonoBehaviour {
//
//	float currentColorIndex = -1;
//	AudioSource toneSource;
//
//	// Use this for initialization
//	void Start () {
//		toneSource = this.gameObject.GetComponent<AudioSource> ();
//	}
//	
//	// Update is called once per frame
//	void Update () {
////		currentColorIndex = IterateThroughColors ();
////		print (currentColorIndex);
//		if (currentColorIndex != -1) {
//			if (toneSource.isPlaying == false) {
//				toneSource.Play ();
//				toneSource.pitch = map(currentColorIndex,0f,4f, .8f, 1.5f);
//			}
//		} 
//		else {
//			toneSource.Pause ();
//		}
//
//	}
//
//	// c#
//	float map(float s, float a1, float a2, float b1, float b2)
//	{
//		return b1 + (s-a1)*(b2-b1)/(a2-a1);
//	}
//
//	float IterateThroughColors(){
//		for (int i = 0; i < GameManager.colorIndex.Length; i++) {
//			if ((GameManager.colorBelowMousePointer.r + .005 >= GameManager.colorIndex [i].r && GameManager.colorBelowMousePointer.r - .005 <= GameManager.colorIndex [i].r) &&
//				(GameManager.colorBelowMousePointer.g + .005 >= GameManager.colorIndex [i].g && GameManager.colorBelowMousePointer.g - .005 <= GameManager.colorIndex [i].g) &&
//				(GameManager.colorBelowMousePointer.b + .005 >= GameManager.colorIndex [i].b && GameManager.colorBelowMousePointer.b - .005 <= GameManager.colorIndex [i].b)) {
//				return i;
//			} 
//		}
//		return -1;
//	}
//}
