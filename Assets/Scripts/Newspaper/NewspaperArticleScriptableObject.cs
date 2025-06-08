using UnityEngine;

[CreateAssetMenu(fileName = "NewspaperArticleScriptableObject", menuName = "ScriptableObjects/NewspaperArticleScriptableObject", order = 1)]
public class NewspaperArticleScriptableObject : ScriptableObject {
    public string title;
    [TextArea] public string content;
}