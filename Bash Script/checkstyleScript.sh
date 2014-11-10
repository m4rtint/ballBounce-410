#!/bin/bash

#Team GGLA
#
#Script takes the two git projects as input and produces two output text files.
#
#OUTPUT DESCRIPTION
#Output consists of two lines per commit. The first line shows the number of lines
#of code currently in the project. The second line will have the number of 
#checkstyle errors found, the commit sha1 hash, and the author's name separated by
#single spaces. Fortunately, all the values required can be found from the output 
#information.
#
#NOTE
#Checkstyle outputs the two lines
#Starting audit...
#Audit done.
#at the beginning and end of every audit. This explains the two lines counted when
#auditing the first commits of team-04 when no java lines are counted.
#
#RUN DIRECTIONS
#Navigate to directory containing git repos, have both repos available
#If editing file in Windows, run
#sed -i 's/\r$//' checkstyleScript.sh
#This removes the error-causing endlines introduced when
#editing the script in Windows
#
#SOURCES CONSULTED
#http://git-scm.com/docs/git-log
#https://en.wikipedia.org/wiki/Xargs

cd team-04
git checkout -q master
git log --pretty="%h %ae" > ../commits.txt
rm ../team4.txt
while read line
do
IFS=' '
array=($line)
git checkout -q "${array[0]}"
cd ..
java -jar checkstyle-6.0-all.jar -c sun_checks.xml -r team-04/edudata/src > "$line".txt
cd team-04
((find ./ -name '*.java' -print0 | xargs -0 cat) | wc -l) >> ../team4.txt
cd ..
wc -l "$line".txt >> team4.txt
rm "$line".txt
echo "processing commit $line"
cd team-04
done < ../commits.txt
git checkout -q master
cd ..
rm commits.txt
sed -i 's/\.txt$//' team4.txt

#REASONING FOR CODE BELOW
#After reading the documentation for git log, it was decided that the 
#--first-parent flag would be the best fit for our purposes. It takes the first
#parent of each commit (important when dealing with branch merging) as the previous
#commit so we can get a "better overview when viewing the evolution of a particular
#topic branch" (taken from the documentation). We need this because the project's 
#size is very large and we can look at only a portion of the historical data.

cd libgdx
git checkout -q master
git log --pretty="%h %ae" -180 --first-parent > ../commits.txt
rm libgdx.txt
mkdir ../srcagg
while read line
do
array=($line)
git checkout -q "${array[0]}"
rm -rf ../srcagg
mkdir ../srcagg
find . -type f -name '*.java' -exec cp {} ../srcagg/ \;
cd ..
java -jar checkstyle-6.0-all.jar -c sun_checks.xml -r srcagg > "$line".txt
cd libgdx
((find ./ -name '*.java' -print0 | xargs -0 cat) | wc -l) >> ../libgdx.txt
cd ..
wc -l "$line".txt >> libgdx.txt
rm "$line".txt
echo "processing commit $line"
cd libgdx
done < ../commits.txt
git checkout -q master
cd ..
rm commits.txt
sed -i 's/\.txt$//' libgdx.txt
