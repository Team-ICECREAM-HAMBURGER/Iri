using TMPro;
using UnityEngine;

public class GameControlSerializableDictionary {
    [System.Serializable] public class SpawnableTrain : 
        SerializableDictionary<GameControlTypeManager.VehicleTrainType, GameObject> { }
    
    [System.Serializable] public class NewsArticle : 
        SerializableDictionary<GameControlTypeManager.NewsArticleType, NewspaperArticleScriptableObject> { }
    
    [System.Serializable] public class FamilySaveData : 
        SerializableDictionary<GameControlTypeManager.FamilyType, GameSaveDataFamily> { }
    [System.Serializable] public class FamilySaveDataScriptableObject : 
        SerializableDictionary<GameControlTypeManager.FamilyType, GameSaveDataFamilyScriptableObject> { }

    [System.Serializable] public class ItemLabelTextDictionary : 
        SerializableDictionary<GameControlTypeManager.ItemLabelType, string> { }
    
    [System.Serializable] public class ItemLabelObjectDictionary :
        SerializableDictionary<GameControlTypeManager.ItemLabelType, TMP_Text> { }

    [System.Serializable] public class ItemScriptDictionary :
        SerializableDictionary<GameControlTypeManager.ItemType, Item> { }

    [System.Serializable] public class ItemGameObjectDictionary :
        SerializableDictionary<GameControlTypeManager.ItemType, GameObject> { }

    [System.Serializable] public class ItemScriptableObjectDictionary : 
        SerializableDictionary<GameControlTypeManager.ItemType, ItemScriptableObject> { }
    
    [System.Serializable] public class EventSaveDataScriptableObject : 
        SerializableDictionary<GameControlTypeManager.EventType, GameSaveDataEventScriptableObject> { }
}