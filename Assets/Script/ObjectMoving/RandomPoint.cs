using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPoint : SetupBehaviour
{
    [SerializeField] protected List<Transform> points;
    public List<Transform> Points => points;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetPoints();
    }
    protected override void Awake()
    {
        base.Awake();
        SetPosition();
    }

    protected virtual void GetPoints()
    {
        if (points.Count != 0) return;
        Transform[] pointsArray = GetComponentsInChildren<Transform>();
        points = new List<Transform>(pointsArray);
        points.Remove(transform);
        Debug.Log("Reset " + nameof(points) + " in " + GetType().Name);
    }

    public virtual void SetPosition()
    {
        foreach (Transform point in points)
        {
            float x = Random.Range(-10, 10);
            float y = Random.Range(-10, 10);
            float z = Random.Range(-10, 10);
            point.position = new Vector3(x, y ,z);
        }
    }
    public virtual void SetFirstToLast()
    {
        Transform firstElement = points[0];
        points.RemoveAt(0);
        points.Add(firstElement);
    }

    protected virtual void OnDrawGizmos()
    {
        foreach (Transform point in points)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(point.position, 1f);
        }
    }
}
