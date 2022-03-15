using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaterScript : MonoBehaviour
{
    [SerializeField] private Vector3 rotateMe;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateMe * Time.deltaTime);
    }
}
