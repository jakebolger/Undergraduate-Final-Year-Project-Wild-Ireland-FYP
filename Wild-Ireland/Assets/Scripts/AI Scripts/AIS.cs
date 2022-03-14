using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIS : MonoBehaviour
{

    private NavMeshAgent _agent;

    public GameObject Player;

    public float EnemyDistanceRun = 4.0f;

    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform pos5;
    public Transform pos6;
    public Transform pos7;
    public Transform pos8;
    public Transform pos9;
    public Transform pos10;


    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        Debug.Log("Distance:" + distance);

        //run away from player

        if (distance < EnemyDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position + dirToPlayer;

            _agent.SetDestination(newPos);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "1")
        {
            _agent.SetDestination(pos2.position);
        }
        if (other.tag == "2")
        {
            _agent.SetDestination(pos3.position);
        }
        if (other.tag == "3")
        {
            _agent.SetDestination(pos4.position);
        }
        if (other.tag == "4")
        {
            _agent.SetDestination(pos5.position);
        }
        if (other.tag == "5")
        {
            _agent.SetDestination(pos6.position);
        }
        if (other.tag == "6")
        {
            _agent.SetDestination(pos7.position);
        }
        if (other.tag == "7")
        {
            _agent.SetDestination(pos8.position);
        }
        if (other.tag == "8")
        {
            _agent.SetDestination(pos9.position);
        }
        if (other.tag == "9")
        {
            _agent.SetDestination(pos10.position);
        }
        if (other.tag == "10")
        {
            _agent.SetDestination(pos1.position);
        }
    }
}