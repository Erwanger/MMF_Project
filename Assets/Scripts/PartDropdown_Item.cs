using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDropdown_Item : MonoBehaviour
{
    public GameObject partStatsDisplay;

    public void OnMouseOverItem()
    {
        if(!partStatsDisplay.activeSelf)
        {
            partStatsDisplay.SetActive(true);
        }
        Debug.Log("Hovering");
    }

    public void OnMouseExitItem()
    {
        if (partStatsDisplay.activeSelf)
        {
            partStatsDisplay.SetActive(false);
        }
        Debug.Log("Exiting");
    }



}
