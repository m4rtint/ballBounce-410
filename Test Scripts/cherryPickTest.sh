#!/bin/bash

# Script selects a few commits to test the code used in checkstyleScript.sh
#
# RUN PRE-CONDITIONS
# Put this script in directory containing the Team-04 project and WalkingPaws
# project.
#
# RUN DIRECTIONS
# Same as checkstyleScript.sh
# If editing file in Windows, run
# sed -i 's/\r$//' cherryPickTest.sh
# ./cherryPickTest.sh
#
# EXPECTED OUTPUT
# The script goes into a particular commit and copies all the java files into
# a particular directory. It then prints out the number of Java lines found
# and the number of files copied. It then goes into the copy target directory
# to print out the same numbers there.
# WE WANT TWO PAIRS OF MATCHING NUMBERS PER TEST

cd team-04
git checkout -q b2009d0
rm -rf ../srcagg
mkdir ../srcagg
find . -type f -name '*.java' -exec cp {} ../srcagg/ \;
#print number of lines of java code in project
find . -type f -name '*.java' -print0 | xargs -0 cat | wc -l
find . -type f -name '*.java' | wc -l
cd ../srcagg
#print number of lines of java code copied into directory
find . -type f -name '*.java' -print0 | xargs -0 cat | wc -l
find . -type f -name '*.java' | wc -l
cd ..

# Test separation
echo

cd walkingpaws
git checkout -q e173cb8
rm -rf ../srcagg
mkdir ../srcagg
find . -type f -name '*.java' -exec cp {} ../srcagg/ \;
#print number of lines of java code in project
find . -type f -name '*.java' -print0 | xargs -0 cat | wc -l
find . -type f -name '*.java' | wc -l
cd ../srcagg
#print number of lines of java code copied into directory
find . -type f -name '*.java' -print0 | xargs -0 cat | wc -l
find . -type f -name '*.java' | wc -l
cd ..
