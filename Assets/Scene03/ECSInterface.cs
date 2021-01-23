using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.UI;

public class ECSInterface : MonoBehaviour
{
    World world;
    EntityManager entityManager;
    public Text sheepCount;
    public Text tankCount;
    public GameObject tankPrefab;
    public GameObject treePrefab;

    // Start is called before the first frame update
    void Start()
    {
        world = World.DefaultGameObjectInjectionWorld;

        entityManager = world.GetExistingSystem<MoveSystem>().EntityManager;

        Debug.Log("All Entities: " + world.GetExistingSystem<MoveSystem>().EntityManager.GetAllEntities().Length);        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = new Vector3(UnityEngine.Random.Range(-10, 10), 0, UnityEngine.Random.Range(-10, 10));
            Instantiate(tankPrefab, pos, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            Vector3 pos = new Vector3(UnityEngine.Random.Range(-10, 10), 0, UnityEngine.Random.Range(-10, 10));
            var settings = GameObjectConversionSettings.FromWorld(world, null);
            var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(treePrefab, settings);
            var instance = entityManager.Instantiate(prefab);
            var position = transform.TransformPoint(new float3(pos.x, 0, pos.z));
            entityManager.SetComponentData(instance, new Translation { Value = position });
            entityManager.SetComponentData(instance, new Rotation { Value = new quaternion(0,0,0,0) });
        }
    }

    public void CountSheep()
    {        
        EntityQuery entityQuery = entityManager.CreateEntityQuery(ComponentType.ReadOnly<Sheep03Data>());
        sheepCount.text = entityQuery.CalculateEntityCount() + "";
    }

    public void CountTank()
    {        
        EntityQuery entityQuery = entityManager.CreateEntityQuery(ComponentType.ReadOnly<Tank03Data>());
        tankCount.text = entityQuery.CalculateEntityCount() + "";
    }

}
