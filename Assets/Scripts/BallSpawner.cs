using UnityEngine;

public class BallSpawner : MonoBehaviour{
    public GameObject ballPrefab;
    public int numberOfBalls = 100;
    public float spawnRadius = 0.5f;
    public int maxSpawnAttemptsPerBall = 10;

    void Start(){
        for(int i = 0; i < numberOfBalls; i++){
            SpawnBall();
        }

        void SpawnBall(){
            int attempts = 0;
            bool placed = false;

            while(!placed && attempts < maxSpawnAttemptsPerBall){
                Vector3 position = RandomPosition();
                if(!Physics.CheckSphere(position, spawnRadius)){
                    Instantiate(ballPrefab, position, Quaternion.identity);
                    placed = true;
                }
                attempts++;
            }
        }

        Vector3 RandomPosition(){
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-5f, 5f);
            float z = Random.Range(-5f, 5f);
            return new Vector3(x, y, z);
        }
    }
}