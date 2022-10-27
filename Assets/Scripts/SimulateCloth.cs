using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MD_Plugin;

public class SimulateCloth : MonoBehaviour
{
    public GameObject thisCube;
    public Transform thisCubeTransform;
    public SphereCollider ClothSphere;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChildOff()
    {
        GameObject CubeInstance = Instantiate(thisCube);
        //Rigidbody rc = CubeInstance.AddComponent(typeof (Rigidbody)) as Rigidbody;
        CubeInstance.AddComponent<SkinnedMeshRenderer>();                         //Add cloth to instance
        CubeInstance.AddComponent<Cloth>();

        //var colliders = new ClothSphereColliderPair[1];
        //colliders[0] = new ClothSphereColliderPair(CubeInstance.GetComponent<SphereCollider>());


        MD_MeshProEditor MDX = CubeInstance.GetComponent<MD_MeshProEditor>();                  //Remove mesh pro editor from instance
        Destroy(MDX);


        Transform CubeTransform = CubeInstance.transform;

        foreach (Transform child in CubeTransform)                                  //Delete vertices from instance
        {
            Debug.Log(child.name);
            Destroy(child.gameObject);
        }
        thisCube.SetActive(false);
    }
}
