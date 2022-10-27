using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewUINext : MonoBehaviour
{
    public GameObject[] ListofObjects;
    private int ObjectNumber;

    public void PreviousModel()
    {
        ListofObjects[ObjectNumber].SetActive(false);

        ObjectNumber--;
        if (ObjectNumber<0)
        {
            ObjectNumber = ListofObjects.Length - 1;
        }

        ListofObjects[ObjectNumber].SetActive(true);
    }

    public void NextModel()
    {
        ListofObjects[ObjectNumber].SetActive(false);

        ObjectNumber++;
        if (ObjectNumber > ListofObjects.Length-1)
        {
            ObjectNumber = 0;
        }

        ListofObjects[ObjectNumber].SetActive(true);
    }
}
