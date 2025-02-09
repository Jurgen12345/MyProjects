package data;

import java.io.*;
import java.util.Iterator;
import java.util.logging.Level;
import java.util.logging.Logger;

// To use these packages you need to add to your project the json-simple-1.1.jar library
//    1. Copy the file json-simple-1.1.jar into your project's src folder
//    2. Right click on Libraries -> Add JAR/Folder. Choose the file from your src folder.
import org.json.simple.parser.JSONParser;
import org.json.simple.JSONObject;
import org.json.simple.parser.ParseException;


public class CJSONFile
{
    private String fileName;
    
    //--------------------------------------------------------------------------
    public CJSONFile(String p_sFileName)
    {
        this.fileName = p_sFileName;
    }
    //--------------------------------------------------------------------------
    //DONE: This methods loads from a JSON file into a dictionary with string key and string value
    public void LoadDict(CDictionaryStringKey p_oDict)
    {   //JSON parser object to parse read file
        JSONParser oJSONParser = new JSONParser();
        try (FileReader oReader = new FileReader(this.fileName))
        {
            // Parse the contents of the file into a JSON object that supports the put/get methods
            JSONObject oFileAsObject = (JSONObject)oJSONParser.parse(oReader);
            p_oDict.Clear(); // Clear all existing entries in the dictionary/hashtable
            // For each key in the JSON file set the proper key-value set in the dictionary/hashtable
            Iterator iterator = oFileAsObject.keySet().iterator(); 
            while(iterator.hasNext())
            {
                // Read K-V pair from JSON 
                String  sJSONKey    = (String)iterator.next();
                String  sJSONValue  = (String)oFileAsObject.get(sJSONKey);
                
                //DONE: Write the necessary code to assign the key-value pair in the dictionary
                p_oDict.setValue(sJSONValue, sJSONKey);
            }
            
        } catch (FileNotFoundException ex) {
            Logger.getLogger(CJSONFile.class.getName()).log(Level.SEVERE, "File not found", ex);
        } catch (IOException ex) {
            Logger.getLogger(CJSONFile.class.getName()).log(Level.SEVERE, "I/O Exception", ex);
        } catch (ParseException ex) {
            Logger.getLogger(CJSONFile.class.getName()).log(Level.SEVERE, "Error while parsing JSON format", ex);
        } 
    }
    //--------------------------------------------------------------------------
    
    
}
