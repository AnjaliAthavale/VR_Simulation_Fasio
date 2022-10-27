using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MD_Plugin;

public class CustomVRInput : MonoBehaviour
{
    public bool IsPressingButton = false;
    public MD_MeshEditorRuntimeVR mdRuntimeVR;

    void Update()
    {
        mdRuntimeVR.GlobalReceived_SetControlInput(IsPressingButton);    
    }
}
