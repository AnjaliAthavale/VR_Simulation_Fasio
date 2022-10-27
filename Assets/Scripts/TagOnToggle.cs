using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagOnToggle : MonoBehaviour
{
    public Toggle t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onValueChange()
    {
        if (t.isOn)
        {
            this.gameObject.tag = "CurrentGarment";
        }
        else
        {
            this.gameObject.tag = "NotCurrentGarment";
        }
    }
}
