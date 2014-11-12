using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;  

public class dataReader : MonoBehaviour {
	public string file = "solution1";

	void Start(){
		Load ("Assets/"+file+".txt");
	}


	public ArrayList ballData = new ArrayList();

	private bool Load(string fileName)
	{
	
			string line;
			// Create a new StreamReader, tell it which file to read and what encoding the file
			// was saved as
			StreamReader theReader = new StreamReader(fileName, Encoding.Default);
			
			// Immediately clean up the reader after this block of code is done.
			// You generally use the "using" statement for potentially memory-intensive objects
			// instead of relying on garbage collection.
			// (Do not confuse this with the using directive for namespace at the 
			// beginning of a class!)
			using (theReader)
			{
				// While there's lines left in the text file, do this:

				do
				{
					line = theReader.ReadLine();
					
					if (line != null)
					{
						// Do whatever you need to do with the text line, it's a string now
						// In this example, I split it into arguments based on comma
						// deliniators, then send that array to DoStuff()
						string[] entries = line.Split(' ');
						if (entries.Length > 0)
						{
					//	Debug.Log("The line was read");
						ballData.Add(entries);


						}

							
					}
				}
				while (line != null);
			//Grabbing Data - Example
			//string[] testData = (string[])ballData[1];	
			//Debug.Log(testData[0]);
				// Done reading, close the reader and return true to broadcast success    
				theReader.Close();
				return true;
			}
		}
	public ArrayList get_data()
	{
		return ballData;
	}

}
