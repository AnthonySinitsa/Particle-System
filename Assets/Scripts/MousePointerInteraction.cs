using UnityEngine;

public class MousePointerInteraction : MonoBehaviour{
    
    [SerializeField, Range(0.01f, 10f)]
    private float forceAmount = 0.01f;

    [SerializeField, Range(0.01f, 10f)]
    private float reactionRadius = 0.01f;

    void Update(){
        if (Input.GetMouseButton(0)){ //checks if left mouse button pressed
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f)){ //adjust max distance
                Collider[] colliders = Physics.OverlapSphere(hit.point, reactionRadius);

                foreach (var collider in colliders){
                    Rigidbody rb = collider.GetComponent<Rigidbody>();
                    if (rb != null){
                        Vector3 direction = collider.transform.position - hit.point;
                        float distance = direction.magnitude;
                        Vector3 force = direction.normalized * (forceAmount / (distance + 1)); // +1 to avoid division by zero
                        rb.AddForce(force, ForceMode.Force);
                    }
                }
            }
        }
    }
}