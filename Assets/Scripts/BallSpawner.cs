using UnityEngine;

public class BallSpawner : MonoBehaviour{
    public GameObject ballPrefab;
    public int numberOfBalls = 100;

    void Start(){
        for(int i = 0; i < numberOfBalls; i++){
            Instantiate(ballPrefab, RandomPosition(), Quaternion.identity);
        }

        Vector3 RandomPosition(){
            float x = RandomPosition.Range(05f, 5f);
            float y = RandomPosition.Range(05f, 5f);
            float z = RandomPosition.Range(05f, 5f);
            return new Vector3(x, y, z);
        }
    }
}