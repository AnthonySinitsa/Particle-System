using UnityEngine;

public class BallSpawner : MonoBehaviour{
    public GameObject ballPrefab;
    public int numberOfBalls = 10;
    public float sphereRadius = 20f; // radius of sphere within the balls will be

    void Start(){
        for(int i = 0; i < numberOfBalls; i++){
            SpawnBallInSphere();
        }
    }

    void SpawnBallInSphere(){
        Vector3 randomPositionInSphere = Random.insideUnitSphere * sphereRadius;
        Vector3 spawnPosition = transform.position + randomPositionInSphere; // adjust spawn position based on spawner's location
        Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
    }
}
