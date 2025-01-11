using UnityEngine;

public class GameSaveDataChapterController : MonoBehaviour {
    [SerializeField] private GameSaveDataManager gameSaveDataManager;
    
    private GameControlLinkedTree<GameSaveDataChapter> chapterTree;
    
    
    private void Init() {
        // Create Chapter Tree
        // this.chapterTree = new(this.gameSaveDataManager.HeadChapterData);
        
    }

    private void Awake() {
        Init();
    }
}