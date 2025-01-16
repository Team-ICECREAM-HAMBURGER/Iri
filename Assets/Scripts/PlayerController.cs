using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float workTime;
    [SerializeField] private float timeScale;

    [HideInInspector] public UnityEvent OnPunchIn;

    private float punchInTime; 
    private float currentTime;

    
    private void Init() {
        this.workTime *= this.timeScale;
        this.OnPunchIn.AddListener(PunchIn);
    }

    private void Awake() {
        Init();
    }
    
    private void PunchIn() {
        Debug.Log("Punch In");
        
        this.punchInTime = Time.time;
        GameDayTimeUpdate(this.punchInTime);
    }

    private void PunchOut() {
        Debug.Log("Punch Out");
        // TODO: 챕터 전환 코드 이식
        
    }
    
    private void GameDayTimeUpdate(float targetTime) {
        StartCoroutine(GameDayTimeUpdateRoutine(targetTime));
    }
    
    IEnumerator GameDayTimeUpdateRoutine(float targetTime) {
        while (this.currentTime < this.workTime) {
            this.currentTime = (Time.time - targetTime);
            yield return new WaitForSecondsRealtime(1);
        }
        
        PunchOut();
    }
}