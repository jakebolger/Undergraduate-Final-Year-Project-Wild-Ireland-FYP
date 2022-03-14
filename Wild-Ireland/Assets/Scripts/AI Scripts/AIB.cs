using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIB : MonoBehaviour
{
    //GameObject variable to put player object in.
    //
    public GameObject PlayerVar;

    //variable for distance
    //
    public float Distance;

    //boolean varibale for isAlert so the agent knows when to follow and not follow the player.
    //
    public bool isAlert;

    public NavMeshAgent badgerAgent;


    // Update is called once per frame
    void Update()
    {

        //calcualting distance between the two vector3s which is the player and the agent(enemy) - this.transform
        //
        Distance = Vector3.Distance(PlayerVar.transform.position, this.transform.position);


        //if statement to set what distance the enemy follows the player
        //
        if (Distance <= 10)
        {
            isAlert = true;
        }
        //tells enemy when to give up
        //
        if (Distance > 10f)
        {
            isAlert = false;
        }
        //if isAlert to false. starts to follow player if its close.
        //
        if (isAlert)
        {

            badgerAgent.isStopped = false;
            badgerAgent.SetDestination(PlayerVar.transform.position);
        }
        //if its not alert set isstopped top true which stops the enemy if you get too far away.
        //
        if (!isAlert)
        {
            badgerAgent.isStopped = true;
        }
    }
}
