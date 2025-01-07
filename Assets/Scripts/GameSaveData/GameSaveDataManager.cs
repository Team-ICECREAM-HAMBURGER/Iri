using UnityEngine;

public class GameSaveDataManager : MonoBehaviour {
    [SerializeField] private GameControlJsonSerializationController gameControlJsonSerializationController;

    [Space(25f)] 
    
    [SerializeField] private GameControlSerializableDictionary.PlayerFamilyScriptableObject playerFamilyScriptableObject;
    
    private GameSaveDataPlayer playerData;
    private GameControlSerializableDictionary.PlayerFamily playerFamilyData;
    private string jsonSerializedData;
    
    private string playerDataFileName;
    private string playerFamilyDataFileName;
    
    
    private void Init() {
        this.playerDataFileName = "Player_Save_Data";
        this.playerFamilyDataFileName = "Family_Save_Data";
        
        // Player Data Init
        InitPlayerData();
        
        // Family Data Init
        InitFamilyData();
    }

    private void InitPlayerData() {
        this.playerData = new(this.playerDataFileName, "Player-01");
        
        if (!SaveDataExists(this.playerDataFileName)) {    
            this.jsonSerializedData = this.gameControlJsonSerializationController.ObjectToJson(this.playerData); 
            this.gameControlJsonSerializationController.WriteJsonFile(this.jsonSerializedData, this.playerDataFileName);
        }
        else {
            this.playerData = this.gameControlJsonSerializationController.LoadJsonFile<GameSaveDataPlayer>(this.playerDataFileName);
        }
    }

    private void InitFamilyData() {
        this.playerFamilyData = new() {
            { GameControlTypeManager.FamilyType.OLD_MOTHER, new (
                this.playerFamilyScriptableObject[GameControlTypeManager.FamilyType.OLD_MOTHER].tag,
                //
                this.playerFamilyScriptableObject[GameControlTypeManager.FamilyType.OLD_MOTHER].familyName,
                this.playerFamilyScriptableObject[GameControlTypeManager.FamilyType.OLD_MOTHER].familyType,
                this.playerFamilyScriptableObject[GameControlTypeManager.FamilyType.OLD_MOTHER].familyStatus
                ) },
            { GameControlTypeManager.FamilyType.WIFE, new (
                this.playerFamilyScriptableObject[GameControlTypeManager.FamilyType.WIFE].tag,
                //
                this.playerFamilyScriptableObject[GameControlTypeManager.FamilyType.WIFE].familyName,
                this.playerFamilyScriptableObject[GameControlTypeManager.FamilyType.WIFE].familyType,
                this.playerFamilyScriptableObject[GameControlTypeManager.FamilyType.WIFE].familyStatus
                ) },
            { GameControlTypeManager.FamilyType.EL_DAUGHTER, new (
                this.playerFamilyScriptableObject[GameControlTypeManager.FamilyType.EL_DAUGHTER].tag,
                //
                this.playerFamilyScriptableObject[GameControlTypeManager.FamilyType.EL_DAUGHTER].familyName,
                this.playerFamilyScriptableObject[GameControlTypeManager.FamilyType.EL_DAUGHTER].familyType,
                this.playerFamilyScriptableObject[GameControlTypeManager.FamilyType.EL_DAUGHTER].familyStatus
                ) },
            { GameControlTypeManager.FamilyType.SEC_SON, new (
                this.playerFamilyScriptableObject[GameControlTypeManager.FamilyType.SEC_SON].tag,
                //
                this.playerFamilyScriptableObject[GameControlTypeManager.FamilyType.SEC_SON].familyName,
                this.playerFamilyScriptableObject[GameControlTypeManager.FamilyType.SEC_SON].familyType,
                this.playerFamilyScriptableObject[GameControlTypeManager.FamilyType.SEC_SON].familyStatus
                ) }
        };
        
        if (!SaveDataExists(this.playerFamilyDataFileName)) {
            this.jsonSerializedData = this.gameControlJsonSerializationController.ObjectToJson(this.playerFamilyData); 
            this.gameControlJsonSerializationController.WriteJsonFile(this.jsonSerializedData, this.playerFamilyDataFileName);
        }
        else {
            this.playerFamilyData =
                this.gameControlJsonSerializationController
                    .LoadJsonFile<GameControlSerializableDictionary.PlayerFamily>(this.playerFamilyDataFileName);
        }
    }

    private bool SaveDataExists(string fileName) {
        return (this.gameControlJsonSerializationController.FileExistsCheck(fileName));
    }
    
    private void Awake() {
        Init();
    }
}