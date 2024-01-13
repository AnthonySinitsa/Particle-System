using UnityEngine;

public class MousePointerInteraction : MonoBehaviour{
    public float forceAmount = 10f;
    public float reactionRadius = 5f;

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
                        rb.AddForce(direction.normalized * forceAmount, ForceMode.Impulse);
                    }
                }
            }
        }
    }
}
