/***
 * Created by: Zabil Tahir
 * Date Created: 1/24/22
 * Last Edited By: Zabil Tahir
 * Last Edited Date: 1/26/22
 * 
 * Description: Spawn multiple cube prefabs into the scene.
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    public GameObject cubePrefab; //New Object
    public float scalingFactor = 0.95f; //amount each cube will shrink each frame
    public int numberOfCubes = 0; //Total number of cubes instatied
    [HideInInspector]
    public List<GameObject> gameObjectList; //list for all the cubes


    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); //instates the List
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; //adding to the number of cubes

        GameObject gObj = Instantiate<GameObject>(cubePrefab); //creates cube instance

        gObj.name = "Cube" + numberOfCubes; //name of cube instance

        Color randColor = new Color(Random.value, Random.value, Random.value); // creates a new random color
        gObj.GetComponent<Renderer>().material.color = randColor;//assigns random color to cubes

        gObj.transform.position = Random.insideUnitSphere; //random location inside a sphere radius of 1 out from 0,0,0

        gameObjectList.Add(gObj); //add to list

        List<GameObject> removeList = new List<GameObject>();//list for removed objects

        foreach(GameObject goTemp in gameObjectList)
        {
            float scale = goTemp.transform.localScale.x; //records current scale
            scale *= scalingFactor; //scale multipled by scale factor
            goTemp.transform.localScale = Vector3.one * scale; //transform scale

            if(scale <= 0.1f)
            {
                removeList.Add(goTemp);
            }//end if (scale <= 0.1f)

        }//end foreach(GameObject goTemp in gameObjectList)

        foreach(GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); //remove from game object list
            Destroy(goTemp); //destroys game object
            
        }//end foreach(GameObject goTemp in removeList

        Debug.Log(removeList.Count); //debugs the remove list
    }
}
