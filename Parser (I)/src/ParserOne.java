import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.HashMap;
import java.util.Vector;

public class ParserOne {
	/* This parser suppose to change the outputs of the bash file output 
	 * into the measure we use to generate our visualization which are the
	 * parameters stated below. These should all be computable by the output
	 * of the bash file. 
	 */ 
	//number of line for each user
	//number of errors for each user
	//number of contributors in the project
	//project size
	//number of errors
	private static Vector<String> inputFile;
	private String fileName;
	private HashMap<Integer, String[]> breakSeq;
	private String[] outputs;
	private int blocks;
	private HashMap<String, Integer[]> contributors;
	private int lastErrors;
	private int lastTot;
	
	
	public ParserOne(){
		fileName = null;
		inputFile = new Vector<String>();
		breakSeq = new HashMap<Integer, String[]>();
		lastErrors = 0;
		lastTot = 0;
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
		while(current <= blocks){
			if(start > 29)
			{
				start = 0;
			}
			String[] blockStat = breakSeq.get(current);
			while(start < blockStat.length){
				splitStat = blockStat[start].split(" ");
				name = splitStat[splitStat.length-1];
				name = name.toLowerCase();
				name = name.replace(".txt", "");
				linesTot = blockStat[start+1];
				int totalLines = Integer.parseInt(linesTot);
				errors = Integer.parseInt(splitStat[1]);
				int difference = errors - lastErrors;
				int totDiff = totalLines - lastTot;
				Integer[] intArray = {0,0};
				
				if(contributors.get(name) != null){
					contributors.put(name, intArray);
				}
				
				intArray = contributors.get(name);
				
				if(totDiff != 0){
					if(contributors.get(name) != null){
						int newLOT = contributors.get(name)[0] + difference;
						intArray[0] = newLOT;
						contributors.put(name, intArray);
					}
				}
				
				if(difference != 0){
					if(contributors.get(name) != null){
						int newLOE = contributors.get(name)[1] + difference;
						intArray[1] = newLOE;
						contributors.put(name, intArray);
					}
				}

				lastErrors = errors;
				lastTot = totalLines;
				
				start+=2;
			}
			outputs = new String[blocks];
			String write = linesTot + "-----" + contributors.size() + ",";
			int i = 0;
			for(Integer[] array: contributors.values()){
				if(contributors.size()-1 == i){
					write = write + array[0] + "-----";
				}else{
					write = write + array[0] + ",";
				}
				i++;
			}
			write = write + errors + "-----" + contributors.size() + ",";
			for(Integer[] array: contributors.values()){
				if(contributors.size()-1 == i){
					write = write + array[1];
				}else{
					write = write + array[1] + ",";
				}
				i++;
			}
			outputs[current] = write;
			current++;
		}
	}
	
	private void BreakInput(){
		blocks = inputFile.size()/30;
		int remain = inputFile.size()%30;
		int seq = 1;
		int index = inputFile.size()-1;
		if(remain > 14)
		{
			blocks++;
		}
		while(blocks >= seq){
			if(blocks == seq){
				if(remain > 14){
					PutToHash(index, seq, remain);
				}
				PutToHash(index, seq, remain+30);
				break;
			}
			PutToHash(index, seq, 30);
			index = index-30;
			seq++;
		}		
	}
	
	private void PutToHash(int index, int seq, int size){
		String[] commits = new String[size];
		int end = index-30;
		System.out.println(seq);
		for(int i = 0; index > end; index--){
			System.out.println(inputFile.get(index));
			commits[i] = inputFile.get(index);
			i++;
		}
		breakSeq.put(seq, commits);
	}
	
	private void WriteFile(){
		 try (BufferedWriter writer = new BufferedWriter(new FileWriter("output.txt"))) {			
			for(int i = 0; i < outputs.length; i++){
				writer.write(outputs[i]);
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
			parser.BreakInput();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			System.out.println("something is wrong");
		}
		
	}
}