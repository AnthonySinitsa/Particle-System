using UnityEngine;

public class BallPositionUpdater : MonoBehaviour{
    void Start(){
        int numBalls = 1000;
        var ballPositions = new NativeArray<float3>(numBalls, Allocator.TempJob);

        UpdateBallPositionsJob positionJob = new UpdateBallPositionsJob{
            ballPositions = ballPositions,
            deltaTime = Time.deltaTime,
            gravity = new float3(0, -9.81f, 0)
        };

        JobHandle positionJobHandle = positionJob.Schedule(numBalls, 64);
        positionJobHandle.Complete();

        //Apply updated positions to balls

        ballPositions.Dispose();
    }
}
