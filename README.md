ballBounce-410
==============

Proper Project of ball Counce

CPSC 410 Project
Sample output image -> ballBounce-410/output image

Raymond Lee, Ronald Lam, Robin Or, Martin Tsang

=====================Testing===================================

Bash Script Testing:



Unity Testing:

DataReader: Created a script to read .txt files passed to Unity. Used Debug.Log to test if the text file was really 
	being read. Parsed each line of text within the text file into a string, then printed out each line onto the 
	console using Debug.Log. Matchup each line of data with each line on the text file given to us. If they all 
	match, then it means that the data has been saved.
	
Ball: Created dumby data so that we are able to determine if the ball was growing and splitting into the 
	correct number of slices. To test the splits, we gave in the values to represent 1 user, and 4 users. This 
	give us the output of a solid ball, and a ball with 4 different coloured slices, where all users did the
	same amount in contribution. (image:http://i.imgur.com/RrQnbkN.jpg). With more dumby data, we tested to see 
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

