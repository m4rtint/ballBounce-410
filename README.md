ballBounce-410
==============

Proper Project of ball Counce

CPSC 410 Project
Sample output image -> ballBounce-410/output image

Raymond Lee, Ronald Lam, Robin Or, Martin Tsang

=====================Testing===================================

Bash Script Testing:


Unity Testing:
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
	that Unity provides when running .Unity projects. 



=====================TEAM NOTES===================================

Need input from bash file like this (based on every 5 commits)?

Lines-----------# of People&lines---------Bump size (errors)--------People error/line

200-------------1,200---------------------10------------------------1,10

2000------------5,200,400,100,1000,200----200-----------------------5,1,0,2,3,194
			
			
			
			

