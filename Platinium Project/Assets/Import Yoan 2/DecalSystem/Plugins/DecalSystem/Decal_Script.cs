using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using DecalSystem;
#endif

public class Decal_Script : MonoBehaviour
{
    public GameObject ThisDecal;

    // Start is called before the first frame update
    void Start()
    {

        CreatePrefab();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreatePrefab()
    {
#if UNITY_EDITOR  

        // instantiate decal

        GameObject obj = Instantiate(ThisDecal, ThisDecal.transform.position, ThisDecal.transform.rotation);

        //decal implementation!!
        var decal = obj.GetComponent<Decal>();
        if (decal) //if this obj has decal script
        {
            var filter = decal.GetComponent<MeshFilter>();
            var mesh = filter.mesh;
            if (mesh != null)
            {
                mesh.name = "DecalMesh";
                filter.mesh = mesh;
            }
            DecalBuilder.Build(decal);

        }
#endif
    }
}