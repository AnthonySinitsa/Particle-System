using UnityEngine;

public class BallSpawner : MonoBehaviour{
    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private GameObject ballsContainer;

    [SerializeField, Range(2, 100)]
    private int ballsX = 5;

    [SerializeField, Range(2, 100)]
    private int ballsY = 5;

    [SerializeField, Range(2, 100)]
    private int ballsZ = 5;

    [SerializeField, Range(0.1f, 2.0f)]
    private float spacing = 1.0f;

    void Start(){
        SpawnBalls();
    }

    void SpawnBalls(){
        Transform[] ballTransforms = new Transform[ballsX * ballsY * ballsZ];

        for(int x = 0; x < ballsX; x++){
            for(int y = 0; y < ballsY; y++){
                for(int z = 0; z < ballsZ; z++){
                    Vector3 position = new Vector3(x * spacing, y * spacing, z * spacing) + transform.position;
                    GameObject newBall = Instantiate(ballPrefab, position, Quaternion.identity);
                    newBall.transform.SetParent(ballsContainer.transform);
                }
            }
        }
    }
}
