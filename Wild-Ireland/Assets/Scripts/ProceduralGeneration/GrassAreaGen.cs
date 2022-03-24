using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassAreaGen : MonoBehaviour
{
    public int grassAreaSize = 25;
    public int grassElementGap = 3;

    public Area[] areas;

    private void Start()
    {

        
        for(int x = 0; x < grassAreaSize; x += grassElementGap)
        {
            for (int z = 0; z < grassAreaSize; z += grassElementGap)
            {

                for (int i = 0; i < areas.Length; i++)
                {

                
                    Area area = areas[i];

                    if (area.CanPlace()) {
                        Vector3 position = new Vector3(x, 5.6f, z);
                        //Vector3 offset = new Vector3(Random.Range(-0.75f, -0.75f), 0f, Random.Range(-0.75f, 0.75f));
                        Vector3 offset = new Vector3(90, 0f, 250);
                        Vector3 rotation = new Vector3(Random.Range(0, 5f), Random.Range(0, 360f), Random.Range(0, 5f));
                        Vector3 scale = Vector3.one * Random.Range(0.75f, 1.25f);

                        GameObject newArea = Instantiate(area.Ranodomaizer());
                        newArea.transform.SetParent(transform);
                        newArea.transform.position = position + offset;
                        newArea.transform.eulerAngles = rotation;
                        newArea.transform.localScale = scale;
                    }
                }
            }

        }
    }
}


[System.Serializable]
public class Area
{
    public string grassname;
    [Range(1, 10)]
    public int density;

    public GameObject[] GrassHolder;

    public bool CanPlace()
    {
        if (Random.Range(0, 10) < density)
            return true;
        else
            return false;
    }

    public GameObject Ranodomaizer()
    {
        return GrassHolder[Random.Range(0, GrassHolder.Length)];
    }

}
