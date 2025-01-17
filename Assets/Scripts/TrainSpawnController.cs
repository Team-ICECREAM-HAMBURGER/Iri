using UnityEngine;

public class TrainSpawnController : MonoBehaviour {
    [SerializeField] private TrainSpawnManager trainSpawnManager;
    
    [Space(10f)]
    
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnTimeMargin;

    
    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag(this.gameObject.tag)) {
            this.trainSpawnManager.OnTrainRespawn.Invoke(
                other.transform.parent.gameObject, 
                this.spawnTime, 
                this.spawnTimeMargin);
        }
    }
}
