using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimGarment : MonoBehaviour
{
    public Toggle SimToggle;
    public GameObject CurrentGarment;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //CurrentGarment = GameObject.FindGameObjectWithTag("CurrentGarment");
    }

    public void makeCloth()
    {
        if (SimToggle.isOn)
        {
            GameObject FinalCloth = Instantiate(CurrentGarment, CurrentGarment.transform.position, CurrentGarment.transform.rotation);
            FinalCloth.tag = "Instantiated";
            CurrentGarment.gameObject.SetActive(false);

            FinalCloth.AddComponent<SkinnedMeshRenderer>();
            FinalCloth.AddComponent<Cloth>();

            GameObject colliderObject = GameObject.FindGameObjectWithTag("Mannequin");

            CapsuleCollider[] clothCapsules = colliderObject.GetComponents<CapsuleCollider>();
            FinalCloth.GetComponent<Cloth>().capsuleColliders = clothCapsules;

            var colliderSpheres = new ClothSphereColliderPair[2];
            colliderSpheres[0] = new ClothSphereColliderPair(colliderObject.GetComponent<SphereCollider>());
            FinalCloth.GetComponent<Cloth>().sphereColliders = colliderSpheres;

        }

        else
        {
            CurrentGarment.gameObject.SetActive(true);
            GameObject FinalCloth = GameObject.FindGameObjectWithTag("Instantiated");
            Destroy(FinalCloth);
        }

    }
}
