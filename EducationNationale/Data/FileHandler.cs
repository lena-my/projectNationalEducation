using Newtonsoft.Json;

namespace EducationNationale
{
    public  static class FileHandler
    {
        private const string JSON_PATH = "./bin/Debug/net8.0/data.json";

        public static DataApp? Deserialize() // DataApp can be null, Converts to an Object
        {
            try
            {
                if (!File.Exists(JSON_PATH)) // check if the file exists
            {
                Console.WriteLine("JSON file not found!");
                return null;
            }
            
            string jsonString = File.ReadAllText(JSON_PATH); // Read JSON file
            DataApp? dataApp = JsonConvert.DeserializeObject<DataApp>(jsonString); // Deserialize the JSON string to an instance of DataApp
            return dataApp;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR DESERIALIZE :: " + e.Message);
                return null;
            }
            

        }
        public static  bool Serialize(DataApp dataApp) // Converts to json
        {
            try
            {
                
             var jsonObj = JsonConvert.SerializeObject(dataApp, Formatting.Indented); // Serialize  an instance of Campus to the JSON string

            File.WriteAllText(JSON_PATH,jsonObj); // Write the file in data.json

            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERREUR SERIALIZE :: " + e.Message);
                return false;
            }

            return true;
        }
    }
}