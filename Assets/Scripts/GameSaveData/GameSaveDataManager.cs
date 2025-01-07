using UnityEngine;
using UnityEngine.Serialization;

public class GameSaveDataManager : MonoBehaviour {
    [SerializeField] private GameControlJsonSerializationController gameControlJsonSerializationController;
    
    [Space(25f)]
    
    private GameSaveDataPlayer playerData;
    private GameControlSerializableDictionary.PlayerFamily playerFamilyData;
    
    
    private void Init() {
        // Player Data Init
        this.playerData = new GameSaveDataPlayer();
        
        if (!SaveDataExists(this.playerData.fileName)) {    
            this.playerData.Init("Player_01");
            
            var jsonSerializedData = this.gameControlJsonSerializationController.ObjectToJson(this.playerData); 
            this.gameControlJsonSerializationController.WriteJsonFile(jsonSerializedData, this.playerData.fileName);
        }
        else {
            this.playerData = this.gameControlJsonSerializationController.LoadJsonFile<GameSaveDataPlayer>(this.playerData.fileName);
        }
        
        Debug.Log(this.playerData.fileName + " : " + this.playerData.playerName);
        
        
        // Family Data Init
        // foreach (var VARIABLE in this.playerFamilyData) {
        //     SaveDataExists(VARIABLE.Value.fileName);
        // }
    }

    private bool SaveDataExists(string fileName) {
        return (this.gameControlJsonSerializationController.FileExistsCheck(fileName));
    }
    
    private void Awake() {
        Init();
    }
}