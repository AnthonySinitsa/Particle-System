using UnityEngine;
using Unity.Collections;
using Unity.Jobs;

public struct MyJob : IJobParallelFor{
    public NativeArray<float> results;

    public void Execute(int index){
        //parallelized computation here
        
    }
}

public class MyJobRunner : MonoBehaviour{
    void Start(){
        int numElements = 1000;
        var jobData = new NativeArray<float>(numElements, Allocator.TempJob);

        MyJob job = new MyJob{
            results = jobData
        };

        //schedule job
        JobHandle jobHandle = job.Schedule(numElements, 64); //64 is batch size

        //Ensure job is complete
        jobHandle.Complete();

        //access results(example)
        for(int i = 0; i < numElements; i++){
            Debug.Log(jobData[i]);
        }

        //dispose of nativearray when done
        jobData.Dispose();
    }   
}