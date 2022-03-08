using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestGenerator : MonoBehaviour
{
    //integer that sets the size of the forest and allows you to change it in the inspector
    //
    public int forestSize = 25;
    //Spacing between elements e.g. trees, rocks, bushes etc.
    //
    public int elementSpacing = 3;

    //Array for elements to add prefabs to
    //
    public Element[] elements;

    //Generate function using terrainGeneratorForest 2 dimensional heightmap array
    //

    public void Generate(float[,] heightMap)
    {
        //looping from 0 to set forest size and incrementing by the element spacing
        //this means every 3 units in unity we will put i elements down
        //
        for (int x = 0; x < forestSize; x += elementSpacing)
        {
            for (int z = 0; z < forestSize; z += elementSpacing)
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    //Gets element, giving priority to trees
                    //
                    Element element = elements[i];

                    //if statement with CanPlace Function
                    //
                    if (element.CanPlace())
                    {
                        //Vector3 position 
                        //passing terrain heightmap into height
                        //
                        Vector3 position = new Vector3(x, heightMap[x, z], z);

                        //new vector3 offset
                        //creating a vector offset thats a random amount to vary position
                        //
                        Vector3 offset = new Vector3(Random.Range(-0.75f, -0.75f), 0f, Random.Range(-0.75f, 0.75f));

                        //creating a vector for rotation giving it a random rotation / tilted
                        //
                        Vector3 rotation = new Vector3(Random.Range(0, 5f), Random.Range(0, 360f), Random.Range(0, 5f));

                        //creating a vector for scale and randomizing it
                        //
                        Vector3 scale = Vector3.one * Random.Range(0.75f, 1.25f);

                        //creating new game object and instantiating the prefab
                        //
                        GameObject newElement = Instantiate(element.GetRandom());

                        //setting the parent so the prefabs dont float around the hierarchy
                        //
                        newElement.transform.SetParent(transform);

                        //setting the elements position
                        //
                        newElement.transform.position = position + offset;

                        //setting the euler angles to allow the trees to look less procedural
                        //
                        newElement.transform.eulerAngles = rotation;
                        //setting the scale
                        //
                        newElement.transform.localScale = scale;

                        //means if tree placed we are not looping to next element
                        //
                        break;
                    }
                }




            }

        }
    }
}

//Make it serializable because we are setting it in the inspector
//
[System.Serializable]
public class Element //Element class 
{
    //name type of element prefab
    //
    public string name;

    //density integer that is locked to a range of 1 to 10
    [Range(1, 10)]
    public int density;

    //creating array Space for Prefabs to go in inspector
    //
    public GameObject[] prefabs;

    //everytime we check this can place we get a random number between 0 and 10
    //and if that number is below our density it returns true
    //
    public bool CanPlace()
    {
        if (Random.Range(0, 10) < density)
            return true;
        else
            return false;
    }

    //class to get objects from the array created. GameObject[]
    //returns game object
    //
    public GameObject GetRandom()
    {

        // Return a random GameObject prefab from the prefabs array.

        return prefabs[Random.Range(0, prefabs.Length)];

    }
}
