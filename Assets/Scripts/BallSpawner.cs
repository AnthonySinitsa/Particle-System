using UnityEngine;

public class BallSpawner : MonoBehaviour{
    public GameObject ballPrefab;
    public int numberOfBalls = 10;
    public Vector3 startPoint = new Vector3(0, 1, 0);
    public Vector3 endPoint = new Vector3(9, 1, 0);

    void Start(){
        for(int i = 0; i < numberOfBalls; i++){
            Vector3 position = Vector3.Lerp(
                startPoint, endPoint, (float)i / (numberOfBalls - 1)
            );
            Instantiate(ballPrefab, position, Quaternion.identity);
        }
    }
}
