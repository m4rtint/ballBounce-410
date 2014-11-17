#!/bin/bash

# Script compiles and runs the second parser on sample data already generated
#
# Runs the same way as the other scripts
# Move to folder containing sample output in the form of 'team4.txt' and 
# 'libgdx.txt', then run
# sed -i 's/\r$//' fusionTest.sh
# ./fusionTest.sh

javac ParserOne.java
java ParserOne team4.txt
java ParserOne libgdx.txt
