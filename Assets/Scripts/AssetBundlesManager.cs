using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
 
public class AssetBundlesManager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GetAssetBundle());
    }

    IEnumerator GetAssetBundle()
    {
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle("https://drive.google.com/drive/folders/1lnFsbg19ywn4nzVsnLgtkE2w4nWayAVj?usp=share_link/");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
        }
    }
}