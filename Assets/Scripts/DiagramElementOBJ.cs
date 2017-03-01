using UnityEngine;
using System.Collections;


public class DiagramElementOBJ : MonoBehaviour {

	public string elementLabel;
	public string elementDescription;
	public string elementLocation;
	public string elementOrder;

	public Color elementColor = Color.clear;

	float tagCount = 0;
	Color CurrentColorUnderMouse = Color.clear;
	Color PrevColorUnderMouse = Color.clear;
	string toSpeak = "";
	string toSpeak2 = "";

	int timer = 0;

	AudioSource toneSource;


	void Start () {
		toneSource = this.gameObject.GetComponent<AudioSource> ();
		toneSource.loop = true;
		toneSource.volume = 0;

		EasyTTSUtil.Initialize (EasyTTSUtil.UnitedStates);

		tagCount = GameObject.FindGameObjectsWithTag("DiagramElement").Length;

		if (tagCount > 0 && GameManager.textList [0] != "") {
				
			int r = int.Parse (GameManager.textList [0]);
			int g = int.Parse (GameManager.textList [1]);
			int b = int.Parse (GameManager.textList [2]);

			elementColor = new Color32((byte)r, (byte)g, (byte)b, 1);
			elementLabel = GameManager.textList [3];
			elementDescription = GameManager.textList [4];
			GameManager.diagramTitle = GameManager.textList [5];	
		}
		if (GameManager.piecewise == true) {	
			elementOrder = GameManager.textList [5];	
			this.enabled = false;
		}
	}

	void Update () {
			

		CurrentColorUnderMouse = GameManager.colorBelowMousePointer;

		float roomForError = .15f;
		//Input.touchCount > 0 && 
		if (Input.touchCount > 0 && (CurrentColorUnderMouse.r + roomForError >=  this.elementColor.r && CurrentColorUnderMouse.r - roomForError <=  this.elementColor.r) &&
			(CurrentColorUnderMouse.g + roomForError >=  this.elementColor.g && CurrentColorUnderMouse.g - roomForError <=  this.elementColor.g) &&
			(CurrentColorUnderMouse.b + roomForError >=  this.elementColor.b && CurrentColorUnderMouse.b - roomForError <=  this.elementColor.b) &&
			CurrentColorUnderMouse.a != 0) {
				
			if (CurrentColorUnderMouse != PrevColorUnderMouse) {
				print ("why2");
				timer = 0;
				EasyTTSUtil.StopSpeech ();
				toSpeak = elementLabel;
				toSpeak2 = elementDescription;
				if(GameManager.haptic == true){
					Handheld.Vibrate ();
				}

				if (toneSource.isPlaying == false) {
					if(GameManager.audio == true){
						toneSource.Play ();
							toneSource.volume = 1f;
						toneSource.pitch = map (tagCount, 0f, 15, .9f, 1.8f);
					}
				} 
			}
			else {
				timer++;
				print ("why");
				if (timer == 10 && toSpeak != "") {
//					EasyTTSUtil.StopSpeech ();
					EasyTTSUtil.SpeechAdd (toSpeak);
					print (toSpeak);
				}

				if (timer == 55 && toSpeak2 != "") {
					print ("eh");
//					EasyTTSUtil.StopSpeech ();
					EasyTTSUtil.SpeechAdd (toSpeak2);
				}
			}

	}
		else {
			if (toneSource.volume > 0) {
				toneSource.volume = 0f;
				toneSource.Stop ();
			}
			toSpeak = "";
			toSpeak2 = "";
//			EasyTTSUtil.StopSpeech ();
		}

		PrevColorUnderMouse = CurrentColorUnderMouse;
	}

		float map(float s, float a1, float a2, float b1, float b2)
		{
			return b1 + (s-a1)*(b2-b1)/(a2-a1);
		}


}
