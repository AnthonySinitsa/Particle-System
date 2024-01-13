using UnityEngine;
using Unity.Collections;
using Unity.Jobs;
using Unity.Burst;
using Unity.Mathematics;

[BurstCompile]
public struct UpdateBallPositionsJob : IJobParallelFor{
    public NativeArray<float3> positions;
    public float deltaTime;
    public float3 gravity;

    public void Execute(int index){
        positions[index] += gravity * deltaTime;
    }
}

public class MyJobRunner : MonoBehaviour{
    void Start(){
        int numBalls = 1000;
        var ballPositions = new NativeArray<float3>(numBalls, Allocator.TempJob);

        UpdateBallPositionsJob job = new UpdateBallPositionsJob
        {
            positions = ballPositions,
            deltaTime = Time.deltaTime,
            gravity = new float3(0, -9.81f, 0)
        };

        JobHandle jobHandle = job.Schedule(numBalls, 64);
        jobHandle.Complete();

        // Apply updated positions to balls
        // ...

        ballPositions.Dispose();
    }
}