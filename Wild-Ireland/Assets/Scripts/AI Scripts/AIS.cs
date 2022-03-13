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
            _agent.SetDestination(pos1.position);
        }
    }
}