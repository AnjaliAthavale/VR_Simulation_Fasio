using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeSelect : MonoBehaviour
{
    public GameObject ThisVertex;
    public GameObject[] AllEdgeVerts;
    public GameObject MainParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ThisVertex.gameObject.GetComponent<MeshRenderer>().material.color == Color.green)
        {
            AllEdgeVerts = GameObject.FindGameObjectsWithTag("TopEdge");

            foreach (var item in AllEdgeVerts)
            {
                item.GetComponent<MeshRenderer>().material.color = Color.green;
                item.transform.parent = ThisVertex.transform;
            }
        }

        else if (ThisVertex.gameObject.GetComponent<MeshRenderer>().material.color == Color.red && (ThisVertex.transform.childCount == 0))
        {
            AllEdgeVerts = GameObject.FindGameObjectsWithTag("TopEdge");

            foreach (var item in AllEdgeVerts)
            {
                item.GetComponent<MeshRenderer>().material.color = Color.red;
                item.transform.parent = ThisVertex.transform;
                
            }
            Debug.Log("PointerDown");
        }
    }
}
