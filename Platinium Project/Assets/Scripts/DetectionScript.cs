using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    //Script par Théo

    public List<Transform> nearestCaddie;
    public Caddie caddie_data;
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
            itemInCartPos1 = closestCaddie.GetChild(2);
            itemInCartPos2 = closestCaddie.GetChild(3);
            itemInCartPos3 = closestCaddie.GetChild(4);
            itemInCartPos4 = closestCaddie.GetChild(5);
        }
        else if(closestCaddie == null)
        {
            itemInCartPos1 = null;
            itemInCartPos2 = null;
            itemInCartPos3 = null;
            itemInCartPos4 = null;
        }

        if(closestCaddie == null)
        {
            nearestCaddie.Clear();
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.parent != null)
        {
            if (nearestCaddie.Count <= 0 && other.gameObject.transform.parent.name.Contains("Caddie"))
            {
                nearestCaddie.Add(other.gameObject.transform.parent);               
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (nearestCaddie.Count > 0)
        {
            nearestCaddie.Clear();
        }

        /*if (other.gameObject.transform.GetComponent<ShoppingCartController>() != null)
        {
            if (nearestCaddie.Count > 0 && !other.gameObject.transform.GetComponent<ShoppingCartController>().cartIsUsed)
            {

            }
        }*/
    }
}
