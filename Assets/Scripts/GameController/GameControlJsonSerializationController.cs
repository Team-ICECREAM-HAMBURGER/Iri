using System.IO;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;

public class GameControlJsonController : MonoBehaviour {
    private string existCheckName;
    private string fileStreamPath;
    
    
    // OBJ -> JSON
    public string ObjectToJson(object objectData) {
        return JsonConvert.SerializeObject(objectData, Formatting.Indented);
    }

    // JSON -> OBJ
    public T JsonToObject<T>(string jsonData) {
        return JsonConvert.DeserializeObject<T>(jsonData);
    }

    public void WriteJsonFile(string fileData, string fileName) {
        this.fileStreamPath = $"{Application.persistentDataPath}/{fileName}.json";
        
        var fileStream = new FileStream(this.fileStreamPath, FileMode.Create);
        var data = Encoding.UTF8.GetBytes(fileData);
        
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    public T LoadJsonFile<T>(string fileName) {
        this.fileStreamPath = $"{Application.persistentDataPath}/{fileName}.json";
        
        if (!File.Exists(this.fileStreamPath)) {
            throw new FileNotFoundException();
        }

        var fileStream = new FileStream(this.fileStreamPath, FileMode.Open);
        var data = new byte[fileStream.Length];

        fileStream.Read(data, 0, data.Length);
        fileStream.Close();

        var loadedJsonData = Encoding.UTF8.GetString(data);

        return JsonConvert.DeserializeObject<T>(loadedJsonData);
    }

    public bool FileExistsCheck() {
        var files = Directory.GetFiles(Application.persistentDataPath, "*.json");

        return (files.Length > 0);
    }
}