using UnityEngine;
using UnityEngine.Events;

public class GameSaveDataChapterController : MonoBehaviour {
    [SerializeField] private GameSaveDataManager gameSaveDataManager;
    [HideInInspector] public UnityEvent<GameControlTypeManager.ChapterType> OnChapterUpdate;


    private void Init() {
        this.OnChapterUpdate.AddListener(ChapterUpdate);
    }

    private void Awake() {
        Init();
    }
    
    public void ChapterUpdate(GameControlTypeManager.ChapterType chapterType) {
        this.gameSaveDataManager.ChapterUpdate(chapterType);
    }
}