using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassAreaBadger : MonoBehaviour
{
    public int grassAreaBadgeSize = 25;
    public int grassElementGapBadge = 3;

    public AreaTwo[] areasTwo;

    private void Start()
    {


        for (int x = 0; x < grassAreaBadgeSize; x += grassElementGapBadge)
        {
            for (int z = 0; z < grassAreaBadgeSize; z += grassElementGapBadge)
            {

                for (int i = 0; i < areasTwo.Length; i++)
                {


                    AreaTwo areaTwo = areasTwo[i];

                    if (areaTwo.CanPlace())
                    {
                        Vector3 position = new Vector3(x, 5.6f, z);
                        //Vector3 offset = new Vector3(Random.Range(-0.75f, -0.75f), 0f, Random.Range(-0.75f, 0.75f));
                        Vector3 offset = new Vector3(100, 0f, -80);
                        Vector3 rotation = new Vector3(Random.Range(0, 5f), Random.Range(0, 360f), Random.Range(0, 5f));
                        Vector3 scale = Vector3.one * Random.Range(0.75f, 1.25f);

                        GameObject newArea2 = Instantiate(areaTwo.Ranodomaizer2());
                        newArea2.transform.SetParent(transform);
                        newArea2.transform.position = position + offset;
                        newArea2.transform.eulerAngles = rotation;
                        newArea2.transform.localScale = scale;
                    }
                }
            }

        }
    }
}

[System.Serializable]
public class AreaTwo
{
    public string grassname;
    [Range(1, 10)]
    public int density;

    public GameObject[] GrassHolder2;

    public bool CanPlace()
    {
        if (Random.Range(0, 10) < density)
            return true;
        else
            return false;
    }

    public GameObject Ranodomaizer2()
    {
        return GrassHolder2[Random.Range(0, GrassHolder2.Length)];
    }

}
