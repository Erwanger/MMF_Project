using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Controller : MonoBehaviour
{
    public Mech[] mechs;

    public float[] mechTimers;
    public bool mechPlaying = false;

    public int _currentTurnId;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMechTab();

        if(mechs == null)
        {
            Debug.LogError("Error: List Mechs is null...");
        }
        else if(mechs.Length == 0)
        {
            Debug.LogError("Error: List Mechs is empty...");
        }

        for(int i=0; i<mechTimers.Length; i++)
        {
            mechTimers[i] = 0.0f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(!mechPlaying)
        {
            for(int i=0; i<mechs.Length; i++)
            {
                mechTimers[i] += Time.deltaTime * mechs[i].agility / 10;
            }

            


        }
        



    }

    void GenerateMechTab()
    {
        //Generate a tab of mechs in the battle
    }

    public void MechTakeTurn(int _id)
    {
        //Method to use to call a turn

        _currentTurnId = _id;
        mechPlaying = true;

    }
}
