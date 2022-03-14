using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class AIF : MonoBehaviour
{

    public Transform Target;
    public float UpdateSpeed = 0.1f;

    private NavMeshAgent Agent;


    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(FollowTarget());
    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds Wait = new WaitForSeconds(UpdateSpeed);

        while (enabled)
        {
            Agent.SetDestination(Target.transform.position);
            yield return Wait;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
