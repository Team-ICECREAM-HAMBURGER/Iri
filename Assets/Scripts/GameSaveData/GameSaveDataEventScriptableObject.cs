using UnityEngine;

[CreateAssetMenu(fileName = "GameSaveDataEventScriptableObject", menuName = "ScriptableObjects/GameSaveDataEventScriptableObject", order = 1)]
public class GameSaveDataEventScriptableObject : ScriptableObject {
    public string tag;
    public string eventName;
    public GameControlTypeManager.EventType eventType;
    public int eventDuration;
}