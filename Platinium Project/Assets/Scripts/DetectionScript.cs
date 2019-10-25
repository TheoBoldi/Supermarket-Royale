using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    //Script par Théo

    public bool isInFront = false;

    public List<Transform> nearestCaddie;
    public Transform closestCaddie;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        closestCaddie = GetClosestObject(nearestCaddie, this.transform);
    }

    public Transform ClosestCaddie()
    {
        return closestCaddie;
    }

    public bool IsObjectInFront()
    {
        return isInFront;
    }

    public Transform GetClosestObject(List<Transform> nearestObject, Transform fromThis)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = fromThis.position;
        foreach (Transform potentialTarget in nearestObject)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!nearestCaddie.Contains(other.gameObject.transform.parent) && other.gameObject.transform.parent.name.Contains("Caddie"))
        {
            nearestCaddie.Add(other.gameObject.transform.parent);
            isInFront = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (nearestCaddie.Contains(other.gameObject.transform))
        {
            nearestCaddie.Remove(other.gameObject.transform.parent);
            isInFront = false;
        }
    }
}
