using UnityEngine;


public class GameControlAdjustBoxColliderBound : MonoBehaviour {
    [SerializeField] private BoxCollider boxCollider;

    private Bounds combinedBounds;

    
    private void Init() {
        this.boxCollider = this.GetComponent<BoxCollider>();
        this.combinedBounds = new (this.transform.position, Vector3.zero);    // Init
        
        
        foreach (Transform childParent in this.transform) {
            var hasChild = true;
            
            foreach (Transform child in childParent) {  // Bounds Calculating
                var childRenderer = child.GetComponent<Renderer>();

                if (childRenderer != null) {
                    this.combinedBounds.Encapsulate(childRenderer.bounds);  // Bounds Grow
                }
                else {
                   hasChild = false;
                   break;
                }
            }

            if (!hasChild) {
                var childParentRenderer = childParent.GetComponent<Renderer>();
                
                this.combinedBounds.Encapsulate(childParentRenderer.bounds);
            }
        }

        this.boxCollider.center = (this.combinedBounds.center - this.boxCollider.transform.position);
        this.boxCollider.size = this.combinedBounds.size;
    }

    private void Awake() {
        Init();
    }
}
