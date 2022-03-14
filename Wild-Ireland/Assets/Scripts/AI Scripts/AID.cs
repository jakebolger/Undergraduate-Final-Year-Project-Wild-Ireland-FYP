using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AID : MonoBehaviour
{

    private NavMeshAgent deerAgent;

    public Transform dpos1;
    public Transform dpos2;
    public Transform dpos3;
    public Transform dpos4;
    public Transform dpos5;
    public Transform dpos6;
    public Transform dpos7;

    // Start is called before the first frame update
    void Start()
    {
        deerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "1")
        {
            deerAgent.SetDestination(dpos2.position);
        }
        if (other.tag == "2")
        {
            deerAgent.SetDestination(dpos3.position);
        }
        if (other.tag == "3")
        {
            deerAgent.SetDestination(dpos4.position);
        }
        if (other.tag == "4")
        {
            deerAgent.SetDestination(dpos5.position);
        }
        if (other.tag == "5")
        {
            deerAgent.SetDestination(dpos6.position);
        }
        if (other.tag == "6")
        {
            deerAgent.SetDestination(dpos7.position);
        }
        if (other.tag == "7")
        {
            deerAgent.SetDestination(dpos1.position);
        }
    }
}
