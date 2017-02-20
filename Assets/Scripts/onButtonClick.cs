using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class onButtonClick : MonoBehaviour {
	
	public InputField Field;
	public Toggle piecewiseToggle;
	public Toggle audioToggle;
	public Toggle hapticToggle;
	bool autoStart = false;
	string autoStartDiagramNumber = "104.png";
	//112.png - cell diagram
	//104.png - atmosphere diagram
	string[] urlParts;

	// Use this for initialization
	void Start () {
		if(autoStart == true){
			autoStartFunction();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClick(){
		urlParts= Field.text.Split('.');
		print (GameManager.piecewise);
		GameManager.url = "http://tonarie.com/php/uploads/"+Field.text;
		GameManager.textUrl = "http://tonarie.com/php/uploads/"+urlParts[0]+".txt";
		GameManager.piecewise = piecewiseToggle.isOn;
		GameManager.audio = audioToggle.isOn;
		GameManager.haptic = hapticToggle.isOn;
	}
	public void autoStartFunction(){
		urlParts= autoStartDiagramNumber.Split('.');
		print (GameManager.piecewise);
		GameManager.url = "http://tonarie.com/php/uploads/"+autoStartDiagramNumber;
		GameManager.textUrl = "http://tonarie.com/php/uploads/"+urlParts[0]+".txt";
		GameManager.piecewise = piecewiseToggle.isOn;
	}
}
