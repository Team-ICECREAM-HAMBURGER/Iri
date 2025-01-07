using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewspaperController : MonoBehaviour {
    [SerializeField] private List<NewspaperArticle> newsPaperArticles;
    [SerializeField] private GameControlSerializableDictionary.NewsArticle newspaperArticleData;
    
    
    private void Init() {
        // TODO: 스토리 진행도에 따라 불러올 기사 데이터를 다르게 설정
        var randomIndexes = new HashSet<int>();

        while (randomIndexes.Count < this.newsPaperArticles.Count) {
            var index = Random.Range(0, this.newspaperArticleData.Count);
            randomIndexes.Add(index);
            Debug.Log(index);
        }

        var randomIndexesList = randomIndexes.ToList();
        var i = 0;
        
        // 뉴스 기사 호출
        foreach (var VARIABLE in randomIndexesList) {
            this.newsPaperArticles[i].Init(this.newspaperArticleData[(GameControlTypeManager.StoryChapterType)VARIABLE]);
            i++;
        }
    }

    private void Awake() {
        Init();
    }
}