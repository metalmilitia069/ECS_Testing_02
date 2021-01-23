using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Jobs;

public class MoveSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        //var jobHandle = Entities.WithName("teucu").ForEach((ref Translation position, ref Rotation rotation) =>
        //{
        //    position.Value += 0.1f * math.forward(rotation.Value);
        //    if (position.Value.z > 50)
        //    {
        //        position.Value.z = -50;
        //    }
        //}).Schedule(inputDeps);


        var jobHandle = Entities.WithName("teucu").ForEach((ref Translation position, ref Rotation rotation, ref SheepData sheepData) =>
        {
            position.Value += 0.01f * math.up();
            //if (position.Value.z > 50)
            //{
            //    position.Value.z = -50;
            //}
        }).Schedule(inputDeps);


        //var jobHandle = new JobHandle();
        return jobHandle;
    }
}
