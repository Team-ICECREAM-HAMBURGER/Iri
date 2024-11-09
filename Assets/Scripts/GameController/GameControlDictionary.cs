using TMPro;

public class GameControlDictionary {
    [System.Serializable] public class TrafficStatus : SerializableDictionary<GameControlTypeManager.vehicleType, GameControlTypeManager.TrafficStatus> { }
    [System.Serializable] public class TrafficStatusTmp : SerializableDictionary<GameControlTypeManager.vehicleType, TMP_Text> { }
    [System.Serializable] public class TrafficStatusText : SerializableDictionary<GameControlTypeManager.TrafficStatus, string> { }
}