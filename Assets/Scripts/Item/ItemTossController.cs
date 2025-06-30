using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ItemTossController : MonoBehaviour {
    [HideInInspector] public UnityEvent onItemToss;
    
    [Space(25f)]
    
    [SerializeField] private Vector3 endPositionVector3;
    [SerializeField] private float duration;
    

    private void Init() {
        this.onItemToss.AddListener(OnItemToss);
    }

    private void Awake() {
        Init();
    }
    
    private void OnItemToss() {
        StartCoroutine(ItemTossCoroutine());
    }
    
    private IEnumerator ItemTossCoroutine() {
        var startPosition = this.gameObject.transform.position;
        var endPosition = (this.gameObject.transform.position + this.endPositionVector3);
        var elapsedTime = 0f;
        
        while (elapsedTime < this.duration) {
            var time = (elapsedTime / this.duration);

            this.gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, time);
            elapsedTime += Time.deltaTime;
            
            yield return null;
        }
        
        this.gameObject.transform.position = endPosition;
    }
}