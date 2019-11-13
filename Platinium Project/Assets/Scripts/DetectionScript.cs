using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    //Script par Théo

    public List<Transform> nearestCaddie;
    public Transform closestCaddie;
    public Transform itemInCartPos1;
    public Transform itemInCartPos2;
    public Transform itemInCartPos3;
    public Transform itemInCartPos4;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        closestCaddie = GetClosestObject(nearestCaddie, this.transform);

        if(closestCaddie != null)
        {
            itemInCartPos1 = closestCaddie.GetChild(4);
            itemInCartPos2 = closestCaddie.GetChild(5);
            itemInCartPos3 = closestCaddie.GetChild(6);
            itemInCartPos4 = closestCaddie.GetChild(7);
        }
        else if(closestCaddie == null)
        {
            itemInCartPos1 = null;
            itemInCartPos2 = null;
            itemInCartPos3 = null;
            itemInCartPos4 = null;
        }
    }

    public Transform ClosestCaddie()
    {
        return closestCaddie;
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.parent != null)
        {
            if (!nearestCaddie.Contains(other.gameObject.transform.parent) && other.gameObject.transform.parent.name.Contains("Caddie"))
            {
                if (nearestCaddie.Count == 0)
                {
                    nearestCaddie.Add(other.gameObject.transform.parent);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.transform.GetComponent<ShoppingCartController>() != null)
        {
            if (nearestCaddie.Contains(other.gameObject.transform.parent) && !other.gameObject.transform.GetComponent<ShoppingCartController>().cartIsUsed)
            {
                nearestCaddie.Remove(other.gameObject.transform.parent);
            }
        }
    }
}
