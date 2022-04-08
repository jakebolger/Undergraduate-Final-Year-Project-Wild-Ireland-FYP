using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxGen : MonoBehaviour
{

    public GameObject FoxOne;
    public GameObject FoxTwo;
    public GameObject FoxThree;
    public int xPos;
    public int zPos;
    public int FoxCount;
    public int RandomRange;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FoxDrop());
    }

    IEnumerator FoxDrop()
    {
        RandomRange = Random.Range(1, 2);

        while (FoxCount <= RandomRange)
        {
            xPos = Random.Range(-48, -94);
            zPos = Random.Range(121, 178);
            Instantiate(FoxOne, new Vector3(xPos, 7, zPos), Quaternion.identity);
            Instantiate(FoxTwo, new Vector3(xPos, 7, zPos), Quaternion.identity);
            Instantiate(FoxThree, new Vector3(xPos, 7, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            FoxCount += 1;
        }
    }


}
