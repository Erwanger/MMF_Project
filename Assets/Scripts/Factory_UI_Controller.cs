using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Factory_UI_Controller : MonoBehaviour
{
    [SerializeField] Factory_Controller factoControl;
    [SerializeField] GameObject[] UI_GameObject;
    [SerializeField] GameObject UI_Storage_Resources;

    [SerializeField] TMP_Dropdown mechListDropdown;
    [SerializeField] TMP_Dropdown partListDropdown;

    /*
     0 Frame
     1 RArm
     2 LArm
     3 Weap1
     4 Weap2
     5 Reactor
     6 Legs
     */
    [SerializeField] TMP_Dropdown[] componentDropdowns;

    Image[] Imgs_Storage;
    public TextMeshProUGUI[] Txt_Storage;
    //Text[] Txt_StorageMax;

    private void Start()
    {
        factoControl = gameObject.GetComponent<Factory_Controller>();

        //Lien entre l'UI et le script
        UI_GameObject = new GameObject[UI_Storage_Resources.transform.childCount];
        Imgs_Storage = new Image[UI_GameObject.Length];
        Txt_Storage = new TextMeshProUGUI[UI_GameObject.Length];
        //Txt_StorageMax = new Text[UI_GameObject.Length];

        for (int i = 0; i < UI_GameObject.Length; i++)
        {
            UI_GameObject[i] = UI_Storage_Resources.transform.GetChild(i).gameObject;
            Imgs_Storage[i] = UI_GameObject[i].transform.GetChild(0).GetComponent<Image>();
            Txt_Storage[i] = UI_GameObject[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        }
        
        //Ajout du contenu de la liste de Parts au dropdown de sélection de Part
        List<string> partNames = new List<string>();

        foreach(Part part in DataCenter.dataSingleton.myPartsList.parts)
        {
            partNames.Add(part.name);
        }

        partListDropdown.AddOptions(partNames);

        partNames.Clear();

        componentDropdowns[0].AddOptions(DataCenter.dataSingleton.myPartsList.GetPartsNamesByComponentType(Part.ComponentType.Frame));
        componentDropdowns[1].AddOptions(DataCenter.dataSingleton.myPartsList.GetPartsNamesByComponentType(Part.ComponentType.Arm));
        componentDropdowns[2].AddOptions(DataCenter.dataSingleton.myPartsList.GetPartsNamesByComponentType(Part.ComponentType.Arm));
        componentDropdowns[3].AddOptions(DataCenter.dataSingleton.myPartsList.GetPartsNamesByComponentType(Part.ComponentType.Weapon));
        componentDropdowns[4].AddOptions(DataCenter.dataSingleton.myPartsList.GetPartsNamesByComponentType(Part.ComponentType.Weapon));
        componentDropdowns[5].AddOptions(DataCenter.dataSingleton.myPartsList.GetPartsNamesByComponentType(Part.ComponentType.Reactor));
        componentDropdowns[6].AddOptions(DataCenter.dataSingleton.myPartsList.GetPartsNamesByComponentType(Part.ComponentType.Leg));
    }


    private void Update()
    {
        //Mise à jour du stock de chaque ressource
        for(int i = 0; i < UI_GameObject.Length; i++)
        {
            Imgs_Storage[i].fillAmount = factoControl.storage[i] / factoControl.storageMax[i];
            Txt_Storage[i].text = "" + (int)factoControl.storage[i];
        }
    }


    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
