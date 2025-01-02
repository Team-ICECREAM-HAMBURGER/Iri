using System;
using TMPro;
using UnityEngine;

[Serializable] public class NewspaperArticle : MonoBehaviour {
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text content;

    private string titleText;
    private string contentText;


    public void Init(NewspaperArticleScriptableObject data) {
        this.titleText = data.title;
        this.contentText = data.content;
        
        this.title.text = this.titleText;
        this.content.text = this.contentText;
    }
}