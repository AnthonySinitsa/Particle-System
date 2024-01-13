using UnityEngine;

public class MousePointerInteraction : MonoBehaviour{
    [SerializeField, Range(0.01f, 10f)]
    private float forceAmount = 1f;

    [SerializeField, Range(0.01f, 10f)]
    private float reactionRadius = 1f;

    void Update(){
        if (Input.GetMouseButton(0)){//left mouse
            ApplyForceToBalls(GetMouseWorldPosition(), true); // Push away
        }
        else if (Input.GetMouseButton(1)){//right mouse
            ApplyForceToBalls(GetMouseWorldPosition(), false); // Pull towards
        }
    }

    private Vector3 GetMouseWorldPosition(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f)){
            return hit.point;
        }
        return Vector3.zero;
    }

    private void ApplyForceToBalls(Vector3 point, bool push){
        Collider[] colliders = Physics.OverlapSphere(point, reactionRadius);
        foreach (var collider in colliders){
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null){
                Vector3 direction = push ? collider.transform.position - point : point - collider.transform.position;
                float distance = direction.magnitude;
                Vector3 force = direction.normalized * (forceAmount / (1 + distance));
                rb.AddForce(force, ForceMode.Force);
            }
        }
    }
}
