using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory_Controller : MonoBehaviour
{
    public enum Resources
    {
        Iron,
        Sand,
        Oil,
        NbResources
    }

    [SerializeField] public float[] storage = new float[(int)Resources.NbResources];
    [SerializeField] public float[] storageMax = new float[(int)Resources.NbResources];
    [SerializeField] float[] income = new float [(int)Resources.NbResources];

    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer>=1.0f)
        {
            for (int j = 0; j < (int)Resources.NbResources; j++)
            {
                storage[j] += income[j];

                if(storage[j]>storageMax[j])
                {
                    storage[j] = storageMax[j];
                }
            }

            timer = 0.0f;
        }
    }


    public void InitializeTab()
    {
         for(int j=0; j < (int)Resources.NbResources; j++)
         {
             storage[j] = 0;
             income[j] = 0.0f;
         }
    }
}
