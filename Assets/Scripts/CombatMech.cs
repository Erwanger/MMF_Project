using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMech : MonoBehaviour
{
    float timerMax = 100.0f;
    float timer = 0.0f;
    bool isAlive = true;
    bool isPaused = true;
    Mech mechData;
    int id;
    Combat_Controller controller;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.mechPlaying)
        {
            isPaused = true;
        }
        else
        {
            isPaused = false;
        }


        if(isAlive)
        {
            if(!isPaused)
            {
                timer += Time.deltaTime * mechData.agility / 10;
            }
        }

        if(timer >= timerMax)
        {
            controller.MechTakeTurn(id);
        }
    }
}
