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

    [System.Serializable]
    public class MechList
    {
        public List<Mech> mechs;

        public List<string> GetMechsNames()
        {
            List<string> result = new List<string>();

            foreach (Mech m in mechs)
            {
                result.Add("#"+m.id+" : "+m.name);
            }

            return result;
        }

        public int IsIdExisting(int _id)
        {
            int i = -1;

            foreach(Mech m in mechs)
            {
                i++;

                if (m.id == _id)
                    return i;
            }

            return -1;
        }

        public int FirstAvailableId()
        {
            int i = 0;
            bool found = false;

            do
            {

                if (IsIdExisting(i) == -1)
                {
                    found = true;
                }
                else
                {
                    i++;
                }

            } while (!found);

            return i;
        }
    }

    public PartsList myPartsList = new PartsList();
    //public PartsList testPartsList = new PartsList();

    public MechList mechList = new MechList();

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

        //Load parts from the file PartData.json
        myPartsList = JsonUtility.FromJson<PartsList>(System.IO.File.ReadAllText(Application.streamingAssetsPath + "/PartData.json"));
        //Load mechs from the file MechList.json
        mechList = JsonUtility.FromJson<MechList>(System.IO.File.ReadAllText(Application.persistentDataPath + "/MechList.json"));
        Debug.Log(Application.persistentDataPath);

        Debug.Log(mechList.mechs.Count);
        Debug.Log(myPartsList.parts.Count);
    }    

    public void Save()
    {
        System.IO.File.WriteAllText(Application.persistentDataPath + "/MechList.json", JsonUtility.ToJson(mechList));
    }

    public void AddMechToList(Mech m)
    {
        mechList.mechs.Add(m);
        Debug.Log(mechList.ToString());
        Debug.Log(mechList.mechs.Count);
    }
}


