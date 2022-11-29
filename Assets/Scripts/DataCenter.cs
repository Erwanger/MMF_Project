using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCenter : MonoBehaviour
{
    [SerializeField]
    TextAsset textJSON;

    [System.Serializable]
    public class PartsList
    {
        public Part[] parts;
    }

    public PartsList myPartsList = new PartsList();
    public PartsList testPartsList = new PartsList();

    // Start is called before the first frame update
    void Start()
    {
        myPartsList = JsonUtility.FromJson<PartsList>(System.IO.File.ReadAllText(Application.persistentDataPath + "/PartData.json"));


        /*testPartsList.parts = new Part [2];
        testPartsList.parts[0] = new Part(ComponentType.Frame, 2, 0, new int[] { 100, 20, 10, 20 }, new List<Part.Resource>() { new Part.Resource(0, 10), new Part.Resource(2, 20) },
            "TestFrame", "My very first frame");
        testPartsList.parts[1] = new Part(ComponentType.Frame, 2, 0, new int[] { 150, 20, 10, 20 }, new List<Part.Resource>() { new Part.Resource(0, 15), new Part.Resource(1, 20) },
            "TestFrame2", "My very second frame");
        System.IO.File.WriteAllText(Application.persistentDataPath + "/PartData.json", JsonUtility.ToJson(testPartsList));
        Debug.Log(Application.persistentDataPath);
        */




    }    
}


