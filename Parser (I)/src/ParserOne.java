import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.Vector;

public class ParserOne {
	/* This parser suppose to change the outputs of the bash file output 
	 * into the measure we use to generate our visualization which are the
	 * parameters stated below. These should all be computable by the output
	 * of the bash file. 
	 */ 
	//number of line for each user
	//number of errors for each use
	//number of contributors in the project
	//project size
	//number of errors
	private static Vector<String> inputFile;
	private String fileName;
	private HashMap<Integer, String[]> breakSeq;
	private ArrayList<String> outputs;
	static final private int BLOCKS = 5;
	private HashMap<String, Integer[]> contributors;
	private int lastErrors;
	private int lastTot;
	private LinkedList<String> order;
	
	
	public ParserOne(){
		fileName = null;
		inputFile = new Vector<String>();
		breakSeq = new HashMap<Integer, String[]>();
		contributors = new HashMap<String, Integer[]>();
		lastErrors = 0;
		lastTot = 0;
		outputs = new ArrayList<String>();
		order = new LinkedList<String>();
	}
	
	private void ReadFile() throws IOException{
		BufferedReader reader = new BufferedReader(new FileReader(fileName));
		String line = reader.readLine();
		int i = 0;
		while(line != null){
			inputFile.add(line);
			line = reader.readLine();
			i++;
		}
	}
	

	public String getFileName() {
		return fileName;
	}

	public void setFileName(String fileName) {
		this.fileName = fileName;
	}

	private void Interp(){
		//break it into chunks of 15 commits, so 30 lines
		BreakInput();
		//create lines of stats in desired format and save it as strings
		FillOutputs();
		//write to a text file called output.txt
		WriteFile();
	}
	
	private void FillOutputs(){
		int current = 1;
		int start = 0;
		String[] splitStat;
		String name;
		String linesTot = "NA";
		int errors = 0;
		String[] splitted = breakSeq.get(1)[1].trim().split(" ");
		String[] splitted1 = breakSeq.get(1)[0].trim().split(" ");
		lastTot = Integer.parseInt(splitted[0]);
		lastErrors = Integer.parseInt(splitted1[0]);
//		int b = 1;
		while(current <= BLOCKS){
			start = 0;
			String[] blockStat = breakSeq.get(current);
			while(start < blockStat.length){
				//System.out.println("values: " + blockStat[start]);
				//System.out.println("blockstat length: " + blockStat.length);
				//System.out.println("number of blocks: " + blocks);
				//System.out.println("current line in block: " + start);
				splitStat = blockStat[start].trim().split(" ");
				name = splitStat[splitStat.length-1];
				name = name.toLowerCase();
				name = name.replace(".txt", "");
				//System.out.println("Name: " + name);
				if(!order.contains(name)){
					order.addLast(name);	
				}
				//System.out.println("value of entering index: " + start);
				//System.out.println(blockStat.length);
				linesTot = blockStat[start+1];
				linesTot = linesTot.replace(" ", "");
				//System.out.println("total number of lines: " + linesTot);
				int totalLines = Integer.parseInt(linesTot);
				System.out.println(lastTot);
				errors = Integer.parseInt(splitStat[0])-2;
				int difference = errors - lastErrors;
				int totDiff = totalLines - lastTot;
				Integer[] intArray = {0,0};
				
				if(!contributors.containsKey(name)){
					contributors.put(name, intArray);
				}
				
				intArray = contributors.get(name);
				
				if(totDiff != 0){
					if(contributors.containsKey(name)){
						int newLOT = contributors.get(name)[0] + totDiff;
						intArray[0] = newLOT;
						contributors.put(name, intArray);
					}
				}
				
				if(difference != 0){
					if(contributors.containsKey(name)){
						int newLOE = contributors.get(name)[1] + difference;
						intArray[1] = newLOE;
						contributors.put(name, intArray);
					}
				}

				lastErrors = errors;
				lastTot = totalLines;
				
				start+=2;
			}
			String write = linesTot + " " + order.size() + ",";
			int i = 0;
			for(String theName: order){
				if(order.size()-1 == i){
					write = write + contributors.get(theName)[0] + " ";
				}else{
					write = write + contributors.get(theName)[0] + ",";
				}
				i++;
			}
			write = write + errors + " " + order.size() + ",";
			i = 0;
			for(String theName: order){
				if(contributors.size()-1 == i){
					write = write + contributors.get(theName)[1];
				}else{
					write = write + contributors.get(theName)[1] + ",";
				}
				i++;
			}
//			i = 1;
//			for(String theName: contributors.keySet()){
//				System.out.println("block " + b + " person " + i + ": " + theName);
//				int a = 1;
//				for(String n: order){
//					System.out.println("Name " + a + " : " + n);
//					a++;
//				}
//				i++;
//			}
			
			//System.out.println("Current block: " + current);
			//System.out.println("created line: " + write);
			outputs.add(write);
			current++;
//			b++;
		}
	}
	
	private void BreakInput(){
//		blocks = inputFile.size()/30;
//		int remain = inputFile.size()%30;
//		int seq = 1;
//		int index = inputFile.size()-1;
//		if(remain > 14)
//		{
//			blocks++;
//		}
//		while(blocks >= seq){
//			if(blocks == seq){
//				if(remain > 14){
//					PutToHash(index, seq, remain);
//				}
//				PutToHash(index, seq, remain+30);
//				break;
//			}
//			PutToHash(index, seq, 30);
//			index = index-30;
//			seq++;
//		}		
		
		int seq = 1;
		int blockSize = (inputFile.size()/10)*2;
		int remain = inputFile.size() - 4*blockSize;
		//System.out.println("remain value: " + remain);
		int index = inputFile.size()-1;
		while(BLOCKS >= seq){
			if(BLOCKS == seq){
				PutToHash(index, seq, remain);
				break;
			}else{
				PutToHash(index, seq, blockSize);
			}
			index = index - blockSize;
			seq++;
		}
	}
	
	private void PutToHash(int index, int seq, int size){
		//System.out.println("size of block " + seq + ": " + size);
		String[] commits = new String[size];
		int end = index-size;
		//System.out.println("block number: " + seq);
		for(int i = 0; index > end; index--){
			//System.out.println(inputFile.get(index));
			//System.out.println("commit aray index number: " + i);
			//System.out.println(index);
			commits[i] = inputFile.get(index);
			//System.out.println("line being saved: " + commits[i]);
			i++;
		}
		breakSeq.put(seq, commits);
	}
	
	private void WriteFile(){
		fileName = fileName.replaceAll(".txt", "");
		 try (BufferedWriter writer = new BufferedWriter(new FileWriter(fileName + "-output.txt"))) {			
			for(int i = 0; i < outputs.size(); i++){
				//System.out.println("print out writes: " + outputs.get(i));
				writer.write(outputs.get(i));
				writer.newLine();
			}
		} catch (IOException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
		}
	}
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		ParserOne parser = new ParserOne();
		parser.setFileName(args[0]);
		try {
			parser.ReadFile();
			//parser.BreakInput();
			parser.Interp();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			System.out.println("something is wrong");
		}
		
	}
}