using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewspaperArticleScriptableObject", menuName = "ScriptableObjects/NewspaperArticleScriptableObject", order = 1)]
[Serializable] public class NewspaperArticleScriptableObject : ScriptableObject{
    public string title;
    [TextArea] public string content;
}

public class NewspaperController : MonoBehaviour {
    [SerializeField] private GameControlJsonController gameControlJsonController;
    [SerializeField] private List<ScriptableObject> newspaperArticleScriptableObjects;
    
    
    private void Init() {
        if (!this.gameControlJsonController.FileExistsCheck()) {
            
            
            
            
            
            
            
            // var serializedObject = this.gameControlJsonController.ObjectToJson(new NewspaperArticleData("Title", "Content"));
            // this.gameControlJsonController.WriteJsonFile(serializedObject);
        }
        
        
    }

    private void Awake() {
        Init();
    }
}