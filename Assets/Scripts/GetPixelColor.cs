using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GetPixelColor : MonoBehaviour {
	public GameObject cube;
	public RawImage test;

	public Color32 ColorBelowMousePointer;
	Rect ColorPanelWidthAndHeight; // set width and height appropriately
	int rectWidth = 100;
	int rectHeight = 100;
	int rectX = 100;
	int rectY = 100;

	bool mouseDown = false;

	void Start(){
	}

	void Update(){
		
	}
	void OnGUI() 
	{ 
	if(GameManager.touch.phase == TouchPhase.Began || GameManager.touch.phase == TouchPhase.Moved || GameManager.touch.phase == TouchPhase.Stationary){

		Texture2D ColorPalleteImage = test.texture as Texture2D;

		ColorPanelWidthAndHeight = test.rectTransform.rect;
			Vector2 pickpos  = Event.current.mousePosition;

		float imageXBasic  = Convert.ToInt32(pickpos.x) - ColorPanelWidthAndHeight.x - Screen.width/2;

		float imageYBasic  =  Convert.ToInt32(pickpos.y) - ColorPanelWidthAndHeight.y  - Screen.height/2;

			int imageX  = (int)(imageXBasic * (ColorPalleteImage.width / (ColorPanelWidthAndHeight.width + 0.0f)));

			int imageY  =  (int)((ColorPanelWidthAndHeight.height - imageYBasic) * (ColorPalleteImage.height / (ColorPanelWidthAndHeight.height + 0.0f)));

			Color32 col  = ColorPalleteImage.GetPixel(imageX, imageY);

		if (pickpos.x > 0 && pickpos.x < Screen.width && pickpos.y > 0 && pickpos.y < Screen.height)
			GameManager.colorBelowMousePointer = col;
		else {
			GameManager.colorBelowMousePointer = Color.clear;
		}
		ColorBelowMousePointer = GameManager.colorBelowMousePointer;

	}
	}
}