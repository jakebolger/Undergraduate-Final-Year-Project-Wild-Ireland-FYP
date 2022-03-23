using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelGen : MonoBehaviour
{

    public GameObject SquirrelOne;
    public GameObject SquirrelTwo;
    public int xPos;
    public int zPos;
    public int SquirrelCount;
    public int RandomRange;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SquirrelDrop());
    }

    IEnumerator SquirrelDrop()
    {
        RandomRange = Random.Range(2, 8);

        while (SquirrelCount <= RandomRange)
        {
            xPos = Random.Range(106, 200);
            zPos = Random.Range(288, 350);
            Instantiate(SquirrelOne, new Vector3(xPos, 6, zPos), Quaternion.identity);
            Instantiate(SquirrelTwo, new Vector3(xPos, 6, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            SquirrelCount += 1;
        }
    }


}
