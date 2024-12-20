using UnityEngine;

public class GameControlColliderBoundsCalculator : MonoBehaviour {
    [SerializeField] private GameControlColliderBoundsManager gameControlColliderBoundsManager;
    
    private Bounds combinedBounds;


    private void Init() {
        this.gameControlColliderBoundsManager.OnBoundsCalculator += this.CalculateColliderBounds;
        this.combinedBounds = new (this.transform.position, Vector3.zero);    // Init
    }

    private void Awake() {
        this.Init();
    }

    private void OnDisable() {
        this.gameControlColliderBoundsManager.OnBoundsCalculator -= this.CalculateColliderBounds;
    }
    
    private Bounds CalculateColliderBounds() {
        var tempTransformRotation = this.transform.rotation;
        
        this.transform.rotation = Quaternion.identity;

        foreach (Transform child in this.transform) {  // Bounds Calculating
            var childRenderer = child.GetComponent<Renderer>();

            if (childRenderer != null) {
                this.combinedBounds.Encapsulate(childRenderer.bounds);  // Bounds Grow
            }
        }

        this.transform.rotation = tempTransformRotation;
        
        return this.combinedBounds;
    }
}
