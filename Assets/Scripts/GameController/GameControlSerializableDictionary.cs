using TMPro;
using UnityEngine;

public class GameControlSerializableDictionary {
    [System.Serializable] public class TrainLocation : SerializableDictionary<GameControlTypeManager.TrainType, GameControlTypeManager.TrainLocationType> { }
    [System.Serializable] public class TrainLocationText : SerializableDictionary<GameControlTypeManager.TrainLocationType, string> { }
    
    [System.Serializable] public class NewsArticle : SerializableDictionary<GameControlTypeManager.NewsArticleType, NewspaperArticleScriptableObject> { }
    
    [System.Serializable] public class FamilySaveData : SerializableDictionary<GameControlTypeManager.FamilyType, GameSaveDataFamily> { }
    [System.Serializable] public class FamilySaveDataScriptableObject : SerializableDictionary<GameControlTypeManager.FamilyType, GameSaveDataFamilyScriptableObject> { }

    [System.Serializable] public class ItemLabel: SerializableDictionary<GameControlTypeManager.ItemLabelType, string> { }

    [System.Serializable] public class ItemSaveData : SerializableDictionary<GameControlTypeManager.ItemType, GameSaveDataItem> { }
    [System.Serializable] public class ItemSaveDataScriptableObject : SerializableDictionary<GameControlTypeManager.ItemType, GameSaveDataItemScriptableObject> { }
    
    [System.Serializable] public class EventSaveDataScriptableObject : SerializableDictionary<GameControlTypeManager.EventType, GameSaveDataEventScriptableObject> { }
}