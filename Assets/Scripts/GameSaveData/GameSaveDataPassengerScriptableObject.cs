using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSaveDataPassengerScriptableObject", menuName = "ScriptableObjects/GameSaveDataPassengerScriptableObject", order = 1)]
public class GameSaveDataPassengerScriptableObject : ScriptableObject {
    public readonly string tag;
    public string passengerName;
    public float weight;
    public List<GameControlTypeManager.ItemType> itemTypes;
    public GameControlTypeManager.vehicleType vehicleType;
    public GameControlTypeManager.PassengerType passengerType;
}