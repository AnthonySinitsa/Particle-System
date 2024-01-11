using UnityEngine;

public class BallSpawner : MonoBehaviour{
    public GameObject ballPrefab;
    public int numberOfBalls = 100;

    void Start(){
        for(int i = 0; i < numberOfBalls; i++){
            Instantiate(ballPrefab, RandomPosition(), Quaternion.identity);
        }

        Vector3 RandomPosition(){
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-5f, 5f);
            float z = Random.Range(-5f, 5f);
            return new Vector3(x, y, z);
        }
    }
}