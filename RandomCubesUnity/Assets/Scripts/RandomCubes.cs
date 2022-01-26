/***
 * Created by: Zabil Tahir
 * Date Created: 1/24/22
 * Last Edited By: Zabil Tahir
 * Last Edited Date: 1/25/22
 * 
 * Description: Spawn multiple cube prefabs into the scene.
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour

{
    public GameObject Cubes;
    private float nextSpawnTime;
    public int MaxCubes = 3;
    public int numCubes = 0;
    public int radius = 7;
    public float spawnDelay = 5;
   



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Shouldspawn())
        {

            SpawnCubes();
        }
    }
    void SpawnCubes()
    {
        nextSpawnTime = Time.time + spawnDelay; //giving a small spawn cooldown

        Vector3 randomSpawn = Random.insideUnitCircle * radius; //have it spawn in random location within a radius

        randomSpawn = new Vector3(randomSpawn.x, 7, randomSpawn.y);
        
        GameObject Go = Instantiate(Cubes, randomSpawn, Quaternion.identity) as GameObject; //actually spawn the prefab and then assign it as a gameobject during runtime

        Go.GetComponent<MeshRenderer>().material.color = Color.HSVToRGB(Random.value, Random.value, Random.value); //have all the cubes be different colors for fun

        numCubes++;
    }


    private bool Shouldspawn()  //limit to how many should spawn
    {
        if (numCubes < MaxCubes)
        {
            return Time.time >= nextSpawnTime;
        }
        else
        {
            return false;
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}
 
