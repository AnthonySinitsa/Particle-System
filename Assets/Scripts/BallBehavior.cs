using UnityEngine;

public class BallBehavior: MonoBehaviour{
    Rigidbody rb;
    public float moveSpeed = 5f;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        Vector3 direction = transform.position - cursorPosition;

        if(direction.magnitude < 1f){ //adjust distance here
            rb.AddForce(direction.normalized * moveSpeed);
        } 
    }
}