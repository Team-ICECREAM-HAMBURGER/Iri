using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GameTimeController : MonoBehaviour {
    [FormerlySerializedAs("playerController")] [SerializeField] private PlayerBehaviour playerBehaviour;
    
    [Space(10f)]
    
    [SerializeField] private float workTime;
    [SerializeField] private float timeScale;
    
    [HideInInspector] public UnityEvent<float> OnTimeUpdate;
    
    private float currentTime;

    
    private void Init() {
        this.currentTime = 0f;
        this.workTime *= this.timeScale;
        this.OnTimeUpdate.AddListener(TimeUpdate);
    }

    private void Awake() {
        Init();
    }

    private void TimeUpdate(float startTime) {
        StopCoroutine(TimeUpdateCoroutine());
        StartCoroutine(TimeUpdateCoroutine(startTime));
    }

    private IEnumerator TimeUpdateCoroutine(float startTime = 0f) {
        while (this.currentTime < this.workTime) {
            yield return new WaitForSecondsRealtime(1f);
            this.currentTime = (Time.time - startTime);
        }

        this.currentTime = 0f;
        this.playerBehaviour.OnPunchOut.Invoke();
    }
}