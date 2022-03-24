using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFrogs : MonoBehaviour
{

    public GameObject FrogOne;
    public int xPos;
    public int zPos;
    public int FrogCount;
    public int RandomRange;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FrogDrop());
    }

    IEnumerator FrogDrop()
    {
        RandomRange = Random.Range(2, 15);

        while (FrogCount <= RandomRange)
        {
            xPos = Random.Range(20, 215);
            zPos = Random.Range(24, 197);
            Instantiate(FrogOne, new Vector3(xPos, 30, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            FrogCount += 1;
        }
    }

    
}
