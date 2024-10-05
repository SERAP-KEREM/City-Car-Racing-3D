using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCarWaypoints : MonoBehaviour
{
    [Header("Opponent Car")]
    public OpponentCar opponentCar;
    public Waypoint currentWaypoint;

    private void Awake()
    {
        opponentCar = GetComponent<OpponentCar>();
    }

    private void Start()
    {
        opponentCar.LocalDestination(currentWaypoint.GetPosition());
    }

    private void Update()
    {
        if(opponentCar.destinationReached)
        {
            currentWaypoint = currentWaypoint.nextWaypoint;
            opponentCar.LocalDestination(currentWaypoint.GetPosition());
        }

    }
}
