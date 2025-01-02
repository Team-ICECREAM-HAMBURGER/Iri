using UnityEngine;

public class NewspaperController : MonoBehaviour {
    [SerializeField] private GameObject newsPaperArticlePrefab;
    [SerializeField] private Transform newPaperArticlePanelTransform;
    
    [Space(25f)]

    [SerializeField] private GameControlSerializableDictionary.NewsArticle newspaperArticles;
    
    
    private void Init() {
        foreach (var VARIABLE in this.newspaperArticles) {
            var obj = Instantiate(newsPaperArticlePrefab, newPaperArticlePanelTransform);
            var objComponent = obj.GetComponent<NewspaperArticle>();
            
            objComponent.Init(VARIABLE.Value);
        }
    }

    private void Awake() {
        Init();
    }
}