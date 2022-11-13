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

    Image[] Imgs_Storage;
    public TextMeshProUGUI[] Txt_Storage;
    //Text[] Txt_StorageMax;

    private void Start()
    {
        factoControl = Camera.main.GetComponent<Factory_Controller>();
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
    }


    private void Update()
    {
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
