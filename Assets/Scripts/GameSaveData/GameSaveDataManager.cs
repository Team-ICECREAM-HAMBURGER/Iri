using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameSaveDataManager : MonoBehaviour {
    [SerializeField] private GameControlJsonSerializationController gameControlJsonSerializationController;
    
    [Space(25f)] 
    
    [SerializeField] private GameControlSerializableDictionary.FamilySaveDataScriptableObject 
        familyDataScriptableObject;
    
    [Space(10f)]
    
    [SerializeField] private List<GameSaveDataChapterScriptableObject> 
        chapterDataScriptableObject;
    // [SerializeField] private GameControlSerializableDictionary.EventSaveDataScriptableObject 
    //     eventDataScriptableObject;
    
    private GameSaveDataPlayer playerData;
    private GameControlSerializableDictionary.FamilySaveData familyData;
    private GameSaveDataChapter headChapterData;
    // private GameSaveDataEvent eventData;
    
    private string playerDataFileName;
    private string familyDataFileName;
    private string chapterDataFileName;
    private string eventDataFileName;
        
    private string jsonSerializedData;
    
    public static UnityEvent OnGameDataSave;

    
    private void Init() {
        this.playerDataFileName = "Player_Save_Data";
        this.familyDataFileName = "Family_Save_Data";
        this.chapterDataFileName = "Chapter_Save_Data";
        // this.eventDataFileName = "Event_Save_Data";
        
        // Player Data Init
        InitPlayerData();
        
        // Family Data Init
        InitFamilyData();
        
        // Game Story Data Init
        InitStoryData();
        
        // Game Event Data Init
        // InitEventData();
    }

    private void InitPlayerData() {
        this.playerData = new(this.playerDataFileName, "Player-01");
        
        if (!SaveDataExistsCheck(this.playerDataFileName)) {    
            CreateNewSaveData(this.playerData, this.playerDataFileName);    
        }
        else {
            this.playerData = LoadSaveData<GameSaveDataPlayer>(this.playerDataFileName);
        }
    }

    private void InitFamilyData() {
        this.familyData = new() {
            { GameControlTypeManager.FamilyType.OLD_MOTHER, new (
                this.familyDataScriptableObject[GameControlTypeManager.FamilyType.OLD_MOTHER].tag,
                //
                this.familyDataScriptableObject[GameControlTypeManager.FamilyType.OLD_MOTHER].familyName,
                this.familyDataScriptableObject[GameControlTypeManager.FamilyType.OLD_MOTHER].familyType,
                this.familyDataScriptableObject[GameControlTypeManager.FamilyType.OLD_MOTHER].familyStatus
                ) },
            { GameControlTypeManager.FamilyType.WIFE, new (
                this.familyDataScriptableObject[GameControlTypeManager.FamilyType.WIFE].tag,
                //
                this.familyDataScriptableObject[GameControlTypeManager.FamilyType.WIFE].familyName,
                this.familyDataScriptableObject[GameControlTypeManager.FamilyType.WIFE].familyType,
                this.familyDataScriptableObject[GameControlTypeManager.FamilyType.WIFE].familyStatus
                ) },
            { GameControlTypeManager.FamilyType.EL_DAUGHTER, new (
                this.familyDataScriptableObject[GameControlTypeManager.FamilyType.EL_DAUGHTER].tag,
                //
                this.familyDataScriptableObject[GameControlTypeManager.FamilyType.EL_DAUGHTER].familyName,
                this.familyDataScriptableObject[GameControlTypeManager.FamilyType.EL_DAUGHTER].familyType,
                this.familyDataScriptableObject[GameControlTypeManager.FamilyType.EL_DAUGHTER].familyStatus
                ) },
            { GameControlTypeManager.FamilyType.SEC_SON, new (
                this.familyDataScriptableObject[GameControlTypeManager.FamilyType.SEC_SON].tag,
                //
                this.familyDataScriptableObject[GameControlTypeManager.FamilyType.SEC_SON].familyName,
                this.familyDataScriptableObject[GameControlTypeManager.FamilyType.SEC_SON].familyType,
                this.familyDataScriptableObject[GameControlTypeManager.FamilyType.SEC_SON].familyStatus
                ) }
        };
        
        if (!SaveDataExistsCheck(this.familyDataFileName)) {
            CreateNewSaveData(this.familyData, this.familyDataFileName);    
        }
        else {
            this.familyData = LoadSaveData<GameControlSerializableDictionary.FamilySaveData>(this.familyDataFileName);
        }
    }

    private void InitStoryData() {
        this.headChapterData = new(this.chapterDataFileName, 
            this.chapterDataScriptableObject[0].chapterName, 
            this.chapterDataScriptableObject[0].chapterType, 
            this.chapterDataScriptableObject[0].savedDateTime);

        if (!SaveDataExistsCheck(this.chapterDataFileName)) {
            CreateNewSaveData(this.headChapterData, this.chapterDataFileName);    
        }
        else {
            this.headChapterData = LoadSaveData<GameSaveDataChapter>(this.chapterDataFileName);
        }
        
    }
    
    // private void InitEventData() {
    //     this.eventData = new(this.eventDataFileName, 
    //         this.eventDataScriptableObject[0].eventName,
    //         this.eventDataScriptableObject[0].eventType,
    //         this.eventDataScriptableObject[0].eventDuration);
    //
    //     if (!SaveDataExistsCheck(this.eventDataFileName)) {
    //         CreateNewSaveData<GameSaveDataEvent>(this.eventData, this.eventDataFileName);
    //     }
    //     else {
    //         this.eventData = LoadSaveData<GameSaveDataEvent>(this.eventDataFileName);
    //     }
    // }

    private bool SaveDataExistsCheck(string fileName) {
        return (this.gameControlJsonSerializationController.FileExistsCheck(fileName));
    }

    private void CreateNewSaveData<T>(T data, string fileName) {
        this.jsonSerializedData = this.gameControlJsonSerializationController.ObjectToJson(data);
        this.gameControlJsonSerializationController.WriteJsonFile(this.jsonSerializedData, fileName);
    }

    private T LoadSaveData<T>(string fileName) {
        return this.gameControlJsonSerializationController.LoadJsonFile<T>(fileName);
    }
    
    private void Awake() {
        Init();
    }
}