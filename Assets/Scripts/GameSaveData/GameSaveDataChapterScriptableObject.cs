using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "GameSaveDataChapterScriptableObject", menuName = "ScriptableObjects/GameSaveDataChapterScriptableObject", order = 1)]
public class GameSaveDataChapterScriptableObject : ScriptableObject {
    public string tag;
    public string chapterName;
    public GameControlTypeManager.ChapterType chapterType;
    public List<GameControlTypeManager.VehicleTrainType> vehicleType;
    public List<GameSaveDataPassengerScriptableObject> passengerScriptableObjects;
    public DateTime savedDateTime;
}