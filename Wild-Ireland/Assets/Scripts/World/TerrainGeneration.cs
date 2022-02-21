using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    //two dimensional array, forest generator script accesses this heightmap
    //
    private float[,] heightMap;

    //integer that sets the size of the terrain and allows you to change it in the inspector
    //
    public int terrainSize;
    //float for the scale if the terrain
    //
    public float terrainScale;
    public float heightMultiplier;

    //reference for the forestgenerator script
    //
    public ForestGenerator Forest;
    public GrassGeneratorScript Grass;



    //meshfilter material and meshrenderer variable.
    //
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    Material material;
    MeshCollider meshCollider;

    private void Start()
    {
        //setting the varibales
        //
        meshCollider = GetComponent<MeshCollider>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshFilter = gameObject.AddComponent<MeshFilter>();
        material = new Material(Shader.Find("Standard"));

        // Validation check to ensure terrainSize is bigger than forestSize, as this will create an indexOutOfBounds exception.
        //
        if (terrainSize < Forest.forestSize)
            terrainSize = Forest.forestSize;
        if (terrainSize < Grass.grassSize)
            terrainSize = Grass.grassSize;

        heightMap = new float[terrainSize, terrainSize];

        GenerateHeightMap();
        Generate();
        Forest.Generate(heightMap);
        Grass.Generate(heightMap);

    }

    //Getheight function, takes in a vector3 and gives it a position in unity.
    //
    float GetHeight(Vector3 position)
    {

        // Return a float representing the height of the terrain at the given position in world space.
        //
        return Mathf.PerlinNoise((position.x + 0.1f) / terrainSize * terrainScale, (position.z + 0.1f) / terrainSize * terrainScale) * heightMultiplier;

    }

    //Generate heightmap function
    //
    void GenerateHeightMap()
    {

        // Loop through each position in our terrain, get the height at that position, and put it in our heightMap array.
        //
        for (int x = 0; x < terrainSize; x++)
        {
            for (int z = 0; z < terrainSize; z++)
            {

                heightMap[x, z] = GetHeight(new Vector3(x, 0f, z));

            }
        }

    }

    void Generate()
    {

        // Initialise arrays and indexes we need for creating our mesh.
        //
        Vector3[] vertices = new Vector3[terrainSize * terrainSize];
        int[] triangles = new int[(terrainSize - 1) * (terrainSize - 1) * 6];
        Vector2[] uvs = new Vector2[terrainSize * terrainSize];

        int vertIndex = 0;
        int triIndex = 0;

        // Loop through each position in terrain, create necessary vertexs, indices, and UV coordinates.
        //
        for (int x = 0; x < terrainSize; x++)
        {
            for (int z = 0; z < terrainSize; z++)
            {

                vertices[vertIndex] = new Vector3(x, heightMap[x, z], z);
                uvs[vertIndex] = new Vector2((float)(x / terrainSize), (float)(z / terrainSize));

                // Make sure we're not on the last row/column of the mesh as setting a triangle from there would create an indexOutOfBoundsException.
                //
                if (x < terrainSize - 1 && z < terrainSize - 1)
                {
                    //adding triangles, represent a quad with 4 point and draw the square with two triangles
                    //
                    triangles[triIndex] = vertIndex;
                    triangles[triIndex + 1] = vertIndex + terrainSize + 1; //+ terrain size gets us down to the next row
                    triangles[triIndex + 2] = vertIndex + terrainSize;
                    triangles[triIndex + 3] = vertIndex + terrainSize + 1;
                    triangles[triIndex + 4] = vertIndex;
                    triangles[triIndex + 5] = vertIndex + 1;

                    //increment the triangle index
                    //
                    triIndex += 6;

                }

                //increment vetext index
                //
                vertIndex++;

            }
        }

        // Create a new mesh and apply our mesh data to it.
        //
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        // Finish off the mesh and set our meshFilter to use it.
        //
        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;

        // Create a simple texture. It's only one colour so it doesn't need to be bigger than 1x1.
        //

        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, Color.green);
        texture.Apply();

        // Apply the texture to our material and apply the material to our MeshRenderer.
        //
        material.mainTexture = texture;
        meshRenderer.material = material;

    }

}
