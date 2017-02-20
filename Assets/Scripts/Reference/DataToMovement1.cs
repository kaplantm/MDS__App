using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;  

public class DataToMovement1 : MonoBehaviour {
	protected FileInfo theSourceFile = null;
	protected StreamReader reader = null;
	protected string text = " "; // assigned to allow first line to be read below
	protected string[] textList; // assigned to allow first line to be read below

	public float xAlign = 0;
	public float yAlign = 0;

	void Start () {
		theSourceFile = new FileInfo (Application.dataPath+"/Resources/"+"Data_1"+".txt");
		reader = theSourceFile.OpenText();
		InvokeRepeating("ReadText", 0f, .05f);
	}

	void Update () {

	}

	void ReadText(){
		text = reader.ReadLine();
		if (text != null) {
			textList = text.Split('&');
			//Console.WriteLine(text);
			//			print (text);
			print (textList[3]);
			float z = float.Parse(textList [2]);
			float x = float.Parse (textList [3]);
			this.gameObject.transform.position = new Vector3 (x/58+xAlign,this.gameObject.transform.position.y,z/58+yAlign);
		}
	}
}

//	int counter = 0;
//
//	private bool Load(string fileName)
//	{
//			string line;
//			// Create a new StreamReader, tell it which file to read and what encoding the file
//			// was saved as
//
//		print(Application.dataPath+fileName);
//		StreamReader theReader = new StreamReader(Application.dataPath+"/Resources/"+fileName+".txt", Encoding.Default);
//			// Immediately clean up the reader after this block of code is done.
//			// You generally use the "using" statement for potentially memory-intensive objects
//			// instead of relying on garbage collection.
//			// (Do not confuse this with the using directive for namespace at the 
//			// beginning of a class!)
//			using (theReader)
//			{
//				// While there's lines left in the text file, do this:
//				do
//				{
//					line = theReader.ReadLine();
//
//					if (line != null)
//					{
//						// Do whatever you need to do with the text line, it's a string now
//						// In this example, I split it into arguments based on comma
//						// deliniators, then send that array to DoStuff()
//						string[] entries = line.Split('&');
//						if (entries.Length > 0)
////							DoStuff(entries);
////						moveObject(entries);
//						StartCoroutine(WaitAndPrint(.1f, entries));
//
//						print(entries[2]);
//					}
//				}
//				while (line != null);
//				// Done reading, close the reader and return true to broadcast success    
//				theReader.Close();
//				return true;
//			}
//		}
//
//	// Use this for initialization
//	void Start () {
//		Load ("Data_1");
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		if (text != null) {
//			text = reader.ReadLine();
//			//Console.WriteLine(text);
//			print (text);
//		}
//	}
//		
//
//}
