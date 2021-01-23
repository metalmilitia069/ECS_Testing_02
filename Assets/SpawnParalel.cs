using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;

public class SpawnParalel : MonoBehaviour
{
    public GameObject sheepPrefab;
    //GameObject[] allSheep;
    Transform[] allSheepTransform;

    const int numSheep = 10000;


    struct MoveJob: IJobParallelForTransform
    {
        public void Execute(int index, TransformAccess transform)
        {
            transform.position += 0.1f * (transform.rotation * new Vector3(0, 0, 1));
            if (transform.position.z > 50)
            {
                transform.position = new Vector3(transform.position.x, 0, -50);
            }
        }
    }

    MoveJob moveJob;
    JobHandle moveHandle;
    TransformAccessArray transforms;


    // Start is called before the first frame update
    void Start()
    {
        allSheepTransform = new Transform[numSheep];

        for (int i = 0; i < numSheep; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
            GameObject sheep = Instantiate(sheepPrefab, pos, Quaternion.identity);
            allSheepTransform[i] = sheep.transform;
        }

        transforms = new TransformAccessArray(allSheepTransform);

        //allSheep = new GameObject[numSheep];

        //for (int i = 0; i < numSheep; i++)
        //{
        //    Vector3 pos = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
        //    allSheep[i] = Instantiate(sheepPrefab, pos, Quaternion.identity);
        //}

        
    }

    private void Update()
    {
        moveJob = new MoveJob { };
        moveHandle = moveJob.Schedule(transforms);


        //for (int i = 0; i < numSheep; i++)
        //{
        //    allSheep[i].transform.Translate(0, 0, 0.1f);
        //    if (allSheep[i].transform.position.z > 50)
        //    {
        //        allSheep[i].transform.position = new Vector3(allSheep[i].transform.position.x, 0, -50);
        //    }
        //}
    }

    private void LateUpdate()
    {
        moveHandle.Complete();
    }

    private void OnDestroy()
    {
        transforms.Dispose();
    }


}
