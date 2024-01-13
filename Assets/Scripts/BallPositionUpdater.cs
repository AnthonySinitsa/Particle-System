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

public class BallPositionUpdater : MonoBehaviour{
    public Transform[] ballTransforms; // Array of ball Transforms
    private NativeArray<float3> ballPositions;
    private bool isInitialized = false;

    void Start(){
        InitializePositions();
    }

    void Update(){
        if(!isInitialized) return;

        UpdateBallPositionsJob job = new UpdateBallPositionsJob
        {
            positions = ballPositions,
            deltaTime = Time.deltaTime,
            gravity = new float3(0, -9.81f, 0)
        };

        JobHandle jobHandle = job.Schedule(ballTransforms.Length, 64);
        jobHandle.Complete();

        // Apply updated positions to balls
        for(int i = 0; i < ballTransforms.Length; i++){
            ballTransforms[i].position = ballPositions[i];
        }
    }

    void InitializePositions(){
        int numBalls = ballTransforms.Length;
        ballPositions = new NativeArray<float3>(numBalls, Allocator.Persistent);

        for(int i = 0; i < numBalls; i ++){
            ballPositions[i] = ballTransforms[i].position;
        }

        isInitialized = true;
    }

    void OnDestroy(){
        if(isInitialized){
            ballPositions.Dispose();
        }
    }

    public void SetBallTransforms(Transform[] transforms){
        ballTransforms = transforms;
        InitializePositions();
    }
}