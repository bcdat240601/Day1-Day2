using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingByListOfPoint : Movement
{
    [SerializeField] protected RandomPoint randomPoint;
    [SerializeField] protected Collider[] colliders;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetRandomPoint();
        SetTarget();
    }

    protected virtual void GetRandomPoint()
    {
        if (randomPoint != null) return;
        randomPoint = FindObjectOfType<RandomPoint>();
        Debug.Log("Reset " + nameof(randomPoint) + " in " + GetType().Name);
    }

    protected override void SetTarget()
    {
        target = randomPoint.Points[0];
    }
    protected override void CheckDestination()
    {
        colliders = Physics.OverlapSphere(transform.position, 0.5f);        
        if (colliders.Length == 0) return;
        if (colliders[0] != target.GetComponent<Collider>()) return;
        randomPoint.SetFirstToLast();
        SetTarget();

    }
}
