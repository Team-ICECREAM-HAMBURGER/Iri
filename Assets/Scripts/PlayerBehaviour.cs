using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviour : GameControlSingleton<PlayerBehaviour> {
    [SerializeField] private GameSaveDataChapterController gameSaveDataChapterController;
    [SerializeField] private GameTimeController gameTimeController;
    
    [Space(10f)]
    
    [HideInInspector] public UnityEvent OnPunchIn;
    [HideInInspector] public UnityEvent OnPunchOut;

    private bool isPunched;
    
    
    private void Init() {
        this.isPunched = false;
        
        this.OnPunchIn.AddListener(PunchIn);
        this.OnPunchOut.AddListener(PunchOut);
    }

    private void Awake() {
        Init();
    }
    
    private void PunchIn() {
        Debug.Log("Punch In");
        
        if (!this.isPunched) {
            this.gameSaveDataChapterController.OnInitChapter.Invoke();
            this.gameTimeController.OnTimeUpdate.Invoke(Time.time);
            this.isPunched = true;
        }
    }

    // EventController/Manager -> Event Control -> ChapterUpdate //
    
    private void PunchOut() {
        Debug.Log("Punch Out");

        if (this.isPunched) {
            this.gameSaveDataChapterController.OnUpdatedChapterSave.Invoke();
            this.isPunched = false;
        }
    }
}