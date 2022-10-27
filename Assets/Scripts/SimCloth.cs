using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimCloth : MonoBehaviour
{
    public GameObject[] FinalCloth;
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
        for (int i = 0; i < FinalCloth.Length; i++)
        {
            FinalCloth[i].GetComponent<Cloth>().enabled = true;
        }

        Invoke("stopCloth", 3);
    }

    private void stopCloth()
    {
        for (int i = 0; i < FinalCloth.Length; i++)
        {
            FinalCloth[i].GetComponent<Cloth>().enabled = false;
        }
        
    }
}
