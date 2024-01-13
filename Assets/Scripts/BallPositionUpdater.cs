using UnityEngine;

public class BallPositionUpdater : MonoBehaviour{
    public Transform[] ballTransforms; // Array of ball Transforms

    void Start(){
        // Initialize Rigidbody settings if needed
        foreach (var ballTransform in ballTransforms){
            var rb = ballTransform.GetComponent<Rigidbody>();
            if (rb != null){
                rb.useGravity = true; // Enable gravity
                // Set other Rigidbody properties as needed
            }
        }
    }
}