using UnityEngine;

public class BallSpawner : MonoBehaviour{
    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private int ballsX = 5;

    [SerializeField]
    private int ballsY = 5;

    [SerializeField]
    private int ballsZ = 5;

    [SerializeField]
    private float spacing = 1.0f;

    void Start(){
        SpawnBalls();
    }

    void SpawnBalls(){
        for(int x = 0; x < ballsX; x++){
            for(int y = 0; y < ballsY; y++){
                for(int z = 0; z < ballsZ; z++){
                    Vector3 position = new Vector3(
                        x * spacing, y * spacing, z * spacing
                    ) + transform.position;
                    Instantiate(ballPrefab, position, Quaternion.identity);
                }
            }
        }
    }
}
