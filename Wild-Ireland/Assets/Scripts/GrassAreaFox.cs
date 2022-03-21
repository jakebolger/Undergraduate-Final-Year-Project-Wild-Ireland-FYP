using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassAreaFox : MonoBehaviour
{
    public int grassAreaFoxSize = 25;
    public int grassElementGapFox = 3;

    public AreaThree[] areasThree;

    private void Start()
    {


        for (int x = 0; x < grassAreaFoxSize; x += grassElementGapFox)
        {
            for (int z = 0; z < grassAreaFoxSize; z += grassElementGapFox)
            {

                for (int i = 0; i < areasThree.Length; i++)
                {


                    AreaThree areaThree = areasThree[i];

                    if (areaThree.CanPlace())
                    {
                        Vector3 position = new Vector3(x, 5.6f, z);
                        //Vector3 offset = new Vector3(Random.Range(-0.75f, -0.75f), 0f, Random.Range(-0.75f, 0.75f));
                        Vector3 offset = new Vector3(-110, 1.5f, 85);
                        Vector3 rotation = new Vector3(Random.Range(0, 5f), Random.Range(0, 360f), Random.Range(0, 5f));
                        Vector3 scale = Vector3.one * Random.Range(0.75f, 1.25f);

                        GameObject newArea3 = Instantiate(areaThree.Ranodomaizer3());
                        newArea3.transform.SetParent(transform);
                        newArea3.transform.position = position + offset;
                        newArea3.transform.eulerAngles = rotation;
                        newArea3.transform.localScale = scale;
                    }
                }
            }

        }
    }
}


[System.Serializable]
public class AreaThree
{
    public string grassname;
    [Range(1, 10)]
    public int density;

    public GameObject[] GrassHolder3;

    public bool CanPlace()
    {
        if (Random.Range(0, 10) < density)
            return true;
        else
            return false;
    }

    public GameObject Ranodomaizer3()
    {
        return GrassHolder3[Random.Range(0, GrassHolder3.Length)];
    }

}
