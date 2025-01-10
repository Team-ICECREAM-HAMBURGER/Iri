using UnityEngine;

public class GameSaveDataEvent {
    public readonly string tag;
    public string eventName;
    public GameControlTypeManager.EventType eventType;
    public int eventDuration;
    
    [SerializeField] private GameSaveDataEventScriptableObject eventScriptableObject;


    public GameSaveDataEvent(string tag, string eventName,
        GameControlTypeManager.EventType eventType, int eventDuration = 1) {
        this.tag = tag;
        this.eventName = eventName;
        this.eventType = eventType;
        this.eventDuration = eventDuration;
    }
}