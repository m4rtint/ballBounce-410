#!/bin/bash

#Script selects a few commits to test the code used in checkstyleScript.sh
#
#RUN DIRECTIONS
#Same as checkstyleScript.sh
#If editing file in Windows, run
#sed -i 's/\r$//' cherryPickTest.sh
#./cherryPickTest.sh
#
#WHAT WE WANT
#Numbers that match, this tests whether the count of java lines in the project is
#the same as the number we get from the folder holding the copied files.
#NOTE THAT SO FAR THIS FAILS!

cd libgdx
git checkout -q f21c838
rm -rf ../srcagg
mkdir ../srcagg
find . -type f -name '*.java' -exec cp {} ../srcagg/ \;
#print number of lines of java code in project
find . -type f -name '*.java' -print0 | xargs -0 cat | wc -l
cd ../srcagg
#print number of lines of java code copied into directory
find . -type f -name '*.java' -print0 | xargs -0 cat | wc -l
