using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ItemTossController : MonoBehaviour {
    [HideInInspector] public UnityEvent OnItemToss;
    
    [Space(25f)]
    
    [SerializeField] private Vector3 endPositionVector3;
    [SerializeField] private float duration;
    

    private void Init() {
        this.OnItemToss.AddListener(ItemToss);
    }

    private void Awake() {
        Init();
    }
    
    private void ItemToss() {
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
        this.gameObject.SetActive(false);
    }
}