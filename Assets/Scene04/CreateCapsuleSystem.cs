using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Jobs;


public class CreateCapsuleSystem : JobComponentSystem
{
    //protected override void OnCreate()
    //{
    //    base.OnCreate();

    //    for (int i = 0; i < 100; i++)
    //    {



    //        var instance = EntityManager.CreateEntity(ComponentType.ReadOnly<LocalToWorld>(), ComponentType.ReadOnly<RenderMesh>(),
    //            ComponentType.ReadOnly<RenderBounds>(), ComponentType.ReadOnly<WorldRenderBounds>(), ComponentType.ReadOnly<NonUniformScale>());/*(ComponentType.ReadWrite<Translation>(), ComponentType.ReadWrite<Rotation>(), ComponentType.ReadOnly<RenderMesh>());*/

    //        float3 position = new float3(UnityEngine.Random.Range(-10, 10), 0, UnityEngine.Random.Range(-10, 10));
    //        float scale = UnityEngine.Random.Range(10, 20);

    //        EntityManager.SetComponentData(instance,
    //            new LocalToWorld
    //            {
    //                Value = new float4x4(rotation: quaternion.identity, translation: position)//new float3(0, 0, 0))
    //            });

    //        //EntityManager.SetComponentData(instance, new Translation { Value = new float3(0, 0, 0) });
    //        //EntityManager.SetComponentData(instance, new Rotation { Value = new quaternion(0, 0, 0, 0) });

    //        EntityManager.SetComponentData(instance,
    //            new NonUniformScale
    //            {
    //                Value = new float3(scale, scale, scale)//(10, 10, 10)
    //            });

    //        var resourceHolder = Resources.Load<GameObject>("ResourceHolder").GetComponent<ResourceHolder>();

    //        EntityManager.SetSharedComponentData(instance,
    //            new RenderMesh
    //            {
    //                mesh = resourceHolder.theMesh,
    //                material = resourceHolder.theMaterial
    //            });
    //    }
    //}



    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        return inputDeps;
    }


}
