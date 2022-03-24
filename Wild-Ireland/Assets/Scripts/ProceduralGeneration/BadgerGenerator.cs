using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgerGenerator : MonoBehaviour
{

    public GameObject BadgerOne;
    public GameObject BadgerTwo;
    public int xPos;
    public int zPos;
    public int BadgerCount;
    public int RandomRange;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BadgerDrop());
    }

    IEnumerator BadgerDrop()
    {
        RandomRange = Random.Range(2, 5);

        while (BadgerCount <= RandomRange)
        {
            xPos = Random.Range(100, 200);
            zPos = Random.Range(-129, -55);
            Instantiate(BadgerOne, new Vector3(xPos, 7, zPos), Quaternion.identity);
            Instantiate(BadgerTwo, new Vector3(xPos, 7, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            BadgerCount += 1;
        }
    }


}
