=====================CPSC 410 Project W01 2014=================

Team: GG-LA
Members: Ronald Lam 40815094, Pak Hong Or 43221118, Martin Tsang 41611112, Raymond Lee 35832112

=====================Run Instructions===========================

Script:

checkstyleScript.sh: Found in the folder "Bash Script". First git clone the Team-04 and libgdx projects, then run the script
	in the directory containing the projects. NOTE THAT THERE MAY BE A WINDOWS LINE FEED PROBLEM! Instructions on how to 
	fix are written in the scripts!
	
Unity:

Once we have the two text outputs, we place those in the Assets folder, and open up Unity (http://unity3d.com/). Once opened,
	we open up our project BallBounce and from the Project tab, we will see the file CPSC410.Unity. We open that, and
	then click Play, and we are able to get our output.  

=====================Testing===================================

Bash Script Testing:

Tests are found in the 'Test Scripts' folder with full instructions and expected output explained in each file. Be aware that
	there may need to be some movement of files and projects to download to run them properly.

smallProjectTest.sh: Runs a version of checkstyleScript.sh on a smaller project not used in our analysis

cherryPickTest.sh: Runs the copy mechanism used in the big project on some sample commits and make sure they match up

fusionTest.sh: Ensures the compilation and running of the Java code in Parser (I) works


Unity Testing:

DataReader: Created a script to read .txt files passed to Unity. Used Debug.Log to test if the text file was really 
	being read. Parsed each line of text within the text file into a string, then printed out each line onto the 
	console using Debug.Log. Matchup each line of data with each line on the text file given to us. If they all 
	match, then it means that the data has been saved.
	
Obtaining Data from another Script:
	The DataReader.cs Script saves all the data read from the given text file into an ArrayList, had to check if 
	the data was accessible from another script. e.g.  transportBackup.cs, resizeBump.cs….etc. So to check if the 
	data was taken,	used Debug.Log and print out values from the first index of the arrayList, which should be the
	first line of data from	the text file given to us.
	
Ball: Created dummy data so that we are able to determine if the ball was growing and splitting into the 
	correct number of slices. To test the splits, we gave in the values to represent 1 user, and 4 users. This 
	give us the output of a solid ball, and a ball with 4 different coloured slices, where all users did the
	same amount in contribution. (image:http://i.imgur.com/RrQnbkN.jpg). With more dummy data, we tested to see 
	what it would look like with different contributions from each user. (image: http://i.imgur.com/ULC8HyW.jpg)
	
Bump: For the bump, we did the exact same thing as the ball, however, we applied the cuts on a different
	gameobject, making the only difference is, instead of a full circle, we have a semi-circle.
	
FlyTime counter: To test the counter, to see if it was starting the timer up at the right time, we used 
	Unity's Debug log, where values would get would get printed out in the log, and displayed in the terminal.
	Utilizing this feature, we were able to determine if code wasn't being reached. For the counter, the Debug 
	log was very helpful (currently most of the debug log is commented out) because it helped us determine 
	if the ball was still grounded. We were able to verify that the ball was grounded by watching the demo video
	that Unity provides when running .Unity projects. For the Debug log, when testing to determine if the ball
	was grounded, we made it output "Is grounded," as soon as it is off the ground, we made the visual output
	pause, and have the log display "In the air." (image: http://i.imgur.com/C4VcdaL.jpg).

