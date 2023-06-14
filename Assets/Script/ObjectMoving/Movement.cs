using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : SetupBehaviour
{
    [SerializeField] protected Rigidbody rigidBody;
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 10f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetRigidBody();
    }
    protected virtual void FixedUpdate()
    {
        Moving();        
        CheckDestination();
    }

    protected virtual void GetRigidBody()
    {
        if (rigidBody != null) return;
        rigidBody = GetComponentInParent<Rigidbody>();
        Debug.Log("Reset "+ nameof(rigidBody) + " in " + GetType().Name);
    }

    protected virtual void Moving()
    {
        Vector3 direction = GetDirection();
        if (direction == Vector3.zero) return;
        rigidBody.MovePosition(transform.parent.position + direction * speed * Time.fixedDeltaTime);
        FacingTarget();
    }

    protected virtual Vector3 GetDirection()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        return direction;
    }   
    
    protected virtual void FacingTarget()
    {
        Vector3 direction = GetDirection();
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.forward);
        transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, targetRotation, 10 * Time.fixedDeltaTime);
    }
    protected abstract void SetTarget();
    protected abstract void CheckDestination();

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, target.position);
    }
}
