using UnityEngine;
using System.Collections;

public class GetPixelColorReference : MonoBehaviour {
	public Texture2D ColorPalleteImage;  //Any Texture Image
	public Color ColorBelowMousePointer;
	public Rect ColorPanelWidthAndHeight; // set width and height appropriately

	void OnGUI() 
	{
		GUI.DrawTexture(ColorPanelWidthAndHeight, ColorPalleteImage);

		if (GUI.RepeatButton(ColorPanelWidthAndHeight, ColorPalleteImage))
		{
			Vector2 pickpos  = Event.current.mousePosition;

			float aaa  = pickpos.x - ColorPanelWidthAndHeight.x;

			float bbb  =  pickpos.y - ColorPanelWidthAndHeight.y;

			int aaa2  = (int)(aaa * (ColorPalleteImage.width / (ColorPanelWidthAndHeight.width + 0.0f)));

			int bbb2  =  (int)((ColorPanelWidthAndHeight.height - bbb) * (ColorPalleteImage.height / (ColorPanelWidthAndHeight.height + 0.0f)));

			Color col  = ColorPalleteImage.GetPixel(aaa2, bbb2);

			ColorBelowMousePointer= col;
		}
	}
}