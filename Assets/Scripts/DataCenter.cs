using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCenter : MonoBehaviour
{
    public static DataCenter dataSingleton;


    [SerializeField]
    TextAsset textJSON;

    [System.Serializable]
    public class PartsList
    {
        public List<Part> parts;
        public List<string> GetPartsNamesByComponentType(Part.ComponentType _c)
        {
            List<string> result = new List<string>();

            foreach(Part p in parts)
            {
                if(p.type == _c)
                {
                    result.Add(p.name);
                }
            }
            return result;
        }

        public Part GetPartByName(string _s)
        {
            foreach (Part p in parts)
            {
                if (p.name == _s)
                {
                    return p;
                }
            }

            return null;
        }

        public Part GetPartById(int _i)
        {
            foreach (Part p in parts)
            {
                if (p.id == _i)
                {
                    return p;
                }
            }

            return null;
        }
    }

    public PartsList myPartsList = new PartsList();
    public PartsList testPartsList = new PartsList();

    // Start is called before the first frame update
    void Start()
    {
        if(dataSingleton == null)
        {
            dataSingleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }


        myPartsList = JsonUtility.FromJson<PartsList>(System.IO.File.ReadAllText(Application.streamingAssetsPath + "/PartData.json"));
        //Debug.Log(Application.persistentDataPath);


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


