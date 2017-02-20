using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;  

public class FileInputToColor : MonoBehaviour {
	protected FileInfo theSourceFile = null;
	protected StreamReader reader = null;
	protected string text = " "; // assigned to allow first line to be read below
	protected string[] textList; // assigned to allow first line to be read below

	public float xAlign = 0;
	public float yAlign = 0;

	public GameObject ElementHolderPrefab;
	public GameObject ElementHolderContainer;
	public AudioClip toneClip;

	void Start () {

		#if UNITY_EDITOR
		theSourceFile = new FileInfo (Application.dataPath+"/StreamingAssets/Diagrams/Testing/"+"volcano"+".txt");
		#elif UNITY_IOS
		theSourceFile = new FileInfo (Application.dataPath + "/Raw/Diagrams/Testing/"+"volcano"+".txt");
		#endif

		reader = theSourceFile.OpenText();
	}

	void Update () {

	}

	void ReadText(){
		text = reader.ReadLine();
		if (text != null) {
			GameManager.textList = text.Split(',');

			GameObject newElementOBJ = Instantiate(ElementHolderPrefab);
			newElementOBJ.transform.parent = ElementHolderContainer.transform;
			AudioSource audioSource = newElementOBJ.AddComponent<AudioSource>();
			audioSource.clip = toneClip;

			print (GameManager.textList[0]);
		}


	}

	string GetStreamingAssetsPath()
	{
		string path;
		#if UNITY_EDITOR
		path = "file:" + Application.persistentDataPath + "/StreamingAssets";
		#elif UNITY_ANDROID
		path = "jar:file://"+ Application.dataPath + "!/assets/";
		#elif UNITY_IOS
		path = "file:" + Application.dataPath + "/Raw";
		#else
		//Desktop (Mac OS or Windows)
		path = "file:"+ Application.dataPath + "/StreamingAssets";
		#endif

		return path;
		}

}
