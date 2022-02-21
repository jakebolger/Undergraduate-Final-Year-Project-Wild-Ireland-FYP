using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGenerator : MonoBehaviour
{
    public int grassPatchSize = 25;
    public int elementSpacing2 = 3;

    public Element1[] elements2;

    private void Start()
    {
        for (int x = 0; x < grassPatchSize; x += elementSpacing2)
        {
            for (int z = 0; z < grassPatchSize; z += elementSpacing2)
            {

                Element1 elemen = elements2[0];
                Vector3 position = new Vector3(x, 1.5f, z);
                Vector3 offset = new Vector3(Random.Range(-0.75f, -0.75f), 0f, Random.Range(-0.75f, -0.75f));
                Vector3 rotation = new Vector3(Random.Range(0, 5f), Random.Range(0, 360f), Random.Range(0, 5f));
                //Vector3 scale = Vector3.one * Random.Range(0.75f, 1.25f);

                GameObject newElement = Instantiate(elemen.grassPrefab);
                newElement.transform.SetParent(transform);
                newElement.transform.position = position + offset;
                newElement.transform.eulerAngles = rotation;
                //newElement.transform.localScale = scale;
            }
        }
    }
}

[System.Serializable]
public class Element1
{
    public string name2;

    public GameObject grassPrefab;
}
