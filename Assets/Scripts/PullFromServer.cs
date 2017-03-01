using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PullFromServer : MonoBehaviour {

	public Texture2D NewTexture;
	private RawImage img;

	public GameObject ElementHolderPrefab;
	public GameObject ElementHolderParentPrefab;
	public GameObject ElementHolderContainer;
	public AudioClip toneClip;
	int counter = 0;
	protected string[] LineList; // assigned to allow first line to be read below
	string longStringFromFile = " ";
	string title = "!";
	public GameObject InputHolder;

	void Start () {
//		StartCoroutine(myCo());
//		StartCoroutine(Check());

	}


	// Update is called once per frame
	void Update () {
		if (GameManager.url != "" && img == null) {
			StartCoroutine(myCo());
			StartCoroutine(Check());
		}
		if (longStringFromFile != " " && counter < LineList.Length) {
			ReadText ();
		}
		else{
			if (GameManager.piecewiseStep == 0 && GameManager.piecewise == true){
				GameManager.UpdatePieceWiseStep();
			}
			else if(title == "!" && longStringFromFile != " " && counter == LineList.Length && GameManager.piecewise == false){
				title = GameManager.diagramTitle;
				print (title);
				EasyTTSUtil.SpeechAdd(title);
			}
			
		}
	}


	public IEnumerator myCo() {
		img = (RawImage)this.gameObject.GetComponent<RawImage>();

		img.texture = new Texture2D (128, 128, TextureFormat.RGBA32, false);
		while (true) {
			WWW imageFromWeb = new WWW(GameManager.url);
			yield return imageFromWeb;
			Destroy (InputHolder);
			imageFromWeb.LoadImageIntoTexture(img.texture as Texture2D);
		}

	}

	private IEnumerator Check()
	{
		if (GameManager.url.Length != 0) {
			WWW textFromWeb = new WWW (GameManager.textUrl);
			yield return textFromWeb;
			if (textFromWeb.error != null) {
				Debug.Log ("Error .. " + textFromWeb.error);
				// for example, often 'Error .. 404 Not Found'
			} else {
				Debug.Log ("Found ... ==>" + textFromWeb.text + "<==");
				// don't forget to look in the 'bottom section'
				// of Unity console to see the full text of
				// multiline console messages.
				longStringFromFile = textFromWeb.text;
				LineList = longStringFromFile.Split ('\n');
			}

		}
		}

		void ReadText(){
		string textLine = LineList[counter];
		counter++;
		if (textLine != null) {
			GameManager.textList = textLine.Split (',');
			if(GameManager.textList[0] != ""){
				GameObject newElementOBJParent = Instantiate (ElementHolderParentPrefab);
				newElementOBJParent.transform.parent = ElementHolderContainer.transform;

				GameObject newElementOBJ = Instantiate (ElementHolderPrefab);
				newElementOBJ.transform.parent = newElementOBJParent.transform;

				AudioSource audioSource = newElementOBJ.AddComponent<AudioSource> ();
				audioSource.clip = toneClip;
			}
		}
	
	}
	
}