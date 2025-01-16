using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSaveDataChapterScriptableObject", menuName = "ScriptableObjects/GameSaveDataChapterScriptableObject", order = 1)]
public class GameSaveDataChapterScriptableObject : ScriptableObject {
    public string tag;
    public string chapterName;
    public GameControlTypeManager.ChapterType chapterType;
    public List<GameControlTypeManager.vehicleType> vehicleType;
    public DateTime savedDateTime;
}