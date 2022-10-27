using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddComponent_Cloth : MonoBehaviour
{
    GameObject FinalCloth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeCloth()
    {
        FinalCloth = GameObject.FindGameObjectWithTag("FinalCloth");
        FinalCloth.AddComponent<SkinnedMeshRenderer>();
        FinalCloth.AddComponent<Cloth>();
        GameObject colliderObject = GameObject.FindGameObjectWithTag("Mannequin");
        CapsuleCollider[] clothCollider = colliderObject.GetComponents<CapsuleCollider>();
        FinalCloth.GetComponent<Cloth>().capsuleColliders = clothCollider;
        Invoke("stopCloth", 3);
    }

    private void stopCloth()
    {
        FinalCloth = GameObject.FindGameObjectWithTag("FinalCloth");
        FinalCloth.gameObject.GetComponent<Cloth>().enabled = false;
    }
}
