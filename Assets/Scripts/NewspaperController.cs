using System.Text;
using UnityEngine;

public class NewspaperController : MonoBehaviour {
    [SerializeField] private GameControlJsonController gameControlJsonController;
    // [SerializeField] private List<ScriptableObject> newspaperArticleScriptableObjects;
    [SerializeField] private GameControlSerializableDictionary.NewsArticle newspaperArticle;

    private StringBuilder serializedObject;
    
    
    private void Init() {
        this.serializedObject = new();
        
        if (!this.gameControlJsonController.FileExistsCheck()) {
            foreach (var VARIABLE in this.newspaperArticle) {
                this.serializedObject.Append(this.gameControlJsonController.ObjectToJson(VARIABLE.Value));
            }
            
            this.gameControlJsonController.WriteJsonFile(this.serializedObject.ToString());
        }
    }

    private void Awake() {
        Init();
    }
}