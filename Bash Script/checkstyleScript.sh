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

cd team-04
git checkout -q master
git log --pretty="%h %an" > ../commits.txt
echo > team4.txt
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

#After this point, script goes through all libgdx commits
#Amount is huge, not for small machines

#cd libgdx
#git checkout -q master
#git log --pretty="%h" > ../commits.txt
#while read line
#do
#git checkout -q "$line"
#mkdir srcagg
#find -name '*.java' -exec mv {} /srcagg \;
#cd ..
#java -jar checkstyle-6.0-all.jar -c sun_checks.xml -r libgdx/srcagg > "$line".txt
#wc -l "$line".txt >> libgdx_checkstyle_count.txt
#rm "$line".txt
#echo "processing commit $line"
#cd libgdx
#done < ../commits.txt
#git checkout -q master
#cd ..
#rm commits.txt
