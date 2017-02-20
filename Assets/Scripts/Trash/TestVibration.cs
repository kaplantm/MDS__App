using UnityEngine;
using System.Collections;

public class TestVibration : MonoBehaviour {
	private RuntimePlatform platform = Application.platform;

	void Update(){
		if(platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer){
			if(Input.touchCount > 0) {
				checkTouch(Input.GetTouch(0).position);
//				if(Input.GetTouch(0).phase == TouchPhase.Began){
//					checkTouch(Input.GetTouch(0).position);
//				}
				checkTouch(Input.GetTouch(0).position);
			}
		}else {
			if(Input.GetMouseButtonDown(0)) {
				checkTouch(Input.mousePosition);
			}
		}
	}

	void checkTouch(Vector3 pos){
		Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
		Vector2 touchPos = new Vector2(wp.x, wp.y);
		Collider2D hit = Physics2D.OverlapPoint(touchPos);
		print ("hey");
		if(hit){
			hit.transform.gameObject.SendMessage("Clicked",0,SendMessageOptions.DontRequireReceiver);
			print ("hi");
			// Handheld.Vibrate();
		}
	}
}