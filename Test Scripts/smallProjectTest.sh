#!/bin/bash

# Runs a version of checkstyleScript.sh on a small project.
# Serves as functional test - we see if output is logical.
#
# Please see cherryPickTest.sh for run instructions.

cd walkingpaws
git checkout -q master
git log --pretty="%h %ae" > ../commits.txt
rm ../walkingpaws.txt
while read line
do
IFS=' '
array=($line)
git checkout -q "${array[0]}"
cd ..
java -jar checkstyle-6.0-all.jar -c sun_checks.xml -r walkingpaws/walkingpaws/src > "$line".txt
cd walkingpaws
((find ./ -name '*.java' -print0 | xargs -0 cat) | wc -l) >> ../walkingpaws.txt
cd ..
wc -l "$line".txt >> walkingpaws.txt
rm "$line".txt
echo "processing commit $line"
cd walkingpaws
done < ../commits.txt
git checkout -q master
cd ..
rm commits.txt
sed -i 's/\.txt$//' walkingpaws.txt
