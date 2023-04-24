using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Factory_UI_Controller : MonoBehaviour
{
    Factory_Controller factoControl;
    [SerializeField] GameObject[] UI_GameObject;
    [SerializeField] GameObject UI_Storage_Resources;

    [SerializeField] TMP_Dropdown mechListDropdown;
    [SerializeField] TMP_Dropdown partListDropdown;

    [SerializeField] GameObject partStatsDisplay;
    public bool partStatsDisplayUpdated = false;

    public void ChangeStatsDisplayUpdated(bool t)
    {
        partStatsDisplayUpdated = t;
    }

    public void OnDropdownItemHighlighted(GameObject dropdownItem)
    {
        string partName = dropdownItem.GetComponent<TMP_Text>().text;
        Part p = DataCenter.dataSingleton.myPartsList.GetPartByName(partName);
        partStatsDisplay.transform.Find("PartStatsSection").Find("NameTxt").GetComponent<TMP_Text>().text = p.name;
        partStatsDisplay.transform.Find("PartStatsSection").Find("DescTxt").GetComponent<TMP_Text>().text = p.description;
        partStatsDisplay.transform.Find("PartStatsSection").Find("Stats").Find("Stat1Txt").GetComponent<TMP_Text>().text = "" + p.hp;
        partStatsDisplay.transform.Find("PartStatsSection").Find("Stats").Find("Stat2Txt").GetComponent<TMP_Text>().text = "" + p.atkPower;
        partStatsDisplay.transform.Find("PartStatsSection").Find("Stats").Find("Stat3Txt").GetComponent<TMP_Text>().text = "" + p.defense;
        partStatsDisplay.transform.Find("PartStatsSection").Find("Stats").Find("Stat4Txt").GetComponent<TMP_Text>().text = "" + p.agility;
        partStatsDisplay.transform.Find("PartStatsSection").Find("Stats").Find("Stat5Txt").GetComponent<TMP_Text>().text = "" + p.speed;
        partStatsDisplay.transform.Find("PartStatsSection").Find("Stats").Find("Stat6Txt").GetComponent<TMP_Text>().text = "" + p.crew;
        partStatsDisplay.transform.Find("PartStatsSection").Find("Stats").Find("Stat7Txt").GetComponent<TMP_Text>().text = "" + p.modSlot;
    }

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

        foreach(Mech m in DataCenter.dataSingleton.mechList.mechs)
        {
            partNames.Add(m.name);

        }

        mechListDropdown.AddOptions(partNames);
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


        if(partStatsDisplay.activeSelf && !partStatsDisplayUpdated)
        {
            //Debug.Log("PartStatsDisplay opened");

            partStatsDisplayUpdated = true;
        }

        if (!partStatsDisplay.activeSelf && partStatsDisplayUpdated)
        {
            //Debug.Log("PartStatsDisplay closed");
            partStatsDisplayUpdated = false;
        }
    }


    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
