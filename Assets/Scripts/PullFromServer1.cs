using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PullFromServer1 : MonoBehaviour {

	public Texture2D NewTexture;
	private RawImage img;
	private string url = "http://tonarie.com/php/uploads/volcanoHoriz001.png";

	void Start () {
		StartCoroutine(myCo());

//		img = (RawImage)this.gameObject.GetComponent<RawImage>();
//
//		img.texture = (Texture2D)NewTexture;
	}


	// Update is called once per frame
	void Update () {
		NewTexture = img.texture as Texture2D;
		try
		{
			NewTexture.GetPixel(0, 0);
		}
		catch(UnityException e)
		{
			if(e.Message.StartsWith("Texture '" + NewTexture.name + "' is not readable"))
			{
				Debug.LogError("Please enable read/write on texture [" + NewTexture.name + "]");
			}
		}
	}


	public IEnumerator myCo() {
		img = (RawImage)this.gameObject.GetComponent<RawImage>();

		img.texture = new Texture2D(128,128);

		while (true) {
			WWW www = new WWW(url);
			yield return www;
			www.LoadImageIntoTexture(img.texture as Texture2D);
		}
	}

}