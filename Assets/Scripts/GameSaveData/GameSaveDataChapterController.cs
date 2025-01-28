using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GameSaveDataChapterController : MonoBehaviour {
    [SerializeField] private GameSaveDataManager gameSaveDataManager;
    
    [HideInInspector] public UnityEvent OnInitChapter;
    [HideInInspector] public UnityEvent OnUpdatedChapterSave;
    [HideInInspector] public UnityEvent<GameControlTypeManager.ChapterType> OnChapterUpdate;

    public GameControlTypeManager.ChapterType CurrentChapter { get; private set; }
    public GameControlTypeManager.ChapterType NextChapter { get; private set; }

    
    private void Init() {
        this.OnInitChapter.AddListener(InitChapter);
        this.OnChapterUpdate.AddListener(ChapterUpdate);
        this.OnUpdatedChapterSave.AddListener(UpdatedChapterSave);
    }
    
    private void InitChapter() {
        this.CurrentChapter = this.gameSaveDataManager.HeadChapterData.chapterType;
    }
    
    private void Awake() {
        Init();
    }
    
    private void UpdatedChapterSave() {
        this.gameSaveDataManager.ChapterUpdate(this.NextChapter);
    }

    private void ChapterUpdate(GameControlTypeManager.ChapterType chapterType) {
        this.NextChapter = chapterType;
    }
}