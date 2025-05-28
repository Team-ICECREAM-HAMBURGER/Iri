using System;
using System.Collections.Generic;

public class GameSaveDataChapter {
    public readonly string tag;
    public string chapterName;
    public GameControlTypeManager.ChapterType chapterType;
    public List<GameControlTypeManager.VehicleTrainType> vehicleTypes;
    public List<GameSaveDataPassengerScriptableObject> passengerScriptableObjects;
    public DateTime savedDateTime;
    
    
    public GameSaveDataChapter(string tag, string chapterName, 
        GameControlTypeManager.ChapterType chapterType, 
        List<GameControlTypeManager.VehicleTrainType> vehicleTypes, 
        List<GameSaveDataPassengerScriptableObject> passengerScriptableObjects,
        DateTime savedDateTime) {
        this.tag = tag;
        this.chapterName = chapterName;
        this.chapterType = chapterType;
        this.vehicleTypes = vehicleTypes;
        this.passengerScriptableObjects = passengerScriptableObjects;
        this.savedDateTime = savedDateTime;
    }
    
    // public void ChapterUpdate(GameSaveDataChapterScriptableObject chapter) {
    //     this.chapterName = chapter.chapterName;
    //     this.chapterType = chapter.chapterType;
    //     this.savedDateTime = chapter.savedDateTime;
    // }
}