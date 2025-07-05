using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviour : GameControlSingleton<PlayerBehaviour> {
    [HideInInspector] public UnityEvent OnPunchIn;
    [HideInInspector] public UnityEvent OnPunchOut;
    
    [SerializeField] private GameSaveDataChapterController gameSaveDataChapterController;
    [SerializeField] private GameTimeController gameTimeController;
    [Space(10f)]
    [SerializeField] private PunchButtonBehaviour punchButtonBehaviour;


    [HideInInspector] public bool isInvestigating; // 현재 검문 중인가?
    private bool isPunched;
    
    
    private void Init() {
        this.isPunched = false;
        this.punchButtonBehaviour.OnPunchIn.AddListener(PunchIn);    
    }

    private void Awake() {
        Init();
    }
    
    private void PunchIn() {
        if (this.isPunched) {
            return;
        }
        
        this.gameSaveDataChapterController.OnInitChapter.Invoke();

        // Debug.Log("Punch In");
        this.OnPunchIn.Invoke();
        this.isPunched = true;
        this.gameTimeController.OnTimeUpdate.Invoke(Time.time);
    }

    private void PunchOut() {
        if (!this.isPunched) {
            return;
        }
        
        this.gameSaveDataChapterController.OnUpdatedChapterSave.Invoke();

        // Debug.Log("Punch Out");
        this.OnPunchOut.Invoke();
        this.isPunched = false;
    }
}