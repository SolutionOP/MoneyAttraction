using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class KeyCodeEnter : MonoBehaviour
{
    [SerializeField] Text keyText;
    [SerializeField] InputField placeHolderBox;
    [SerializeField] UsersSettings usersSettings;

    private void Awake()
    {
        if (usersSettings.isKeyEntered)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void EnterKey()
    {
        string deviceID = SystemInfo.deviceUniqueIdentifier;
        StartCoroutine(SendKeyToServer(deviceID, keyText.text));
    }

    private IEnumerator SendKeyToServer(string deviceID, string keyCode)
    {
        UnityWebRequest www = UnityWebRequest.Get($"http://ngmschool.pserver.ru/check?key={keyCode}&device={deviceID}");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success || www.downloadHandler.text == "{\"status\":404,\"message\":\"Wrong key\"}")
        {
            placeHolderBox.GetComponent<Image>().color = new Color(1, 0.627451f, 0.627451f, 1);
            yield return new WaitForSecondsRealtime(0.5f);
            placeHolderBox.GetComponent<Image>().color = Color.white;
            Debug.Log("Error");
            placeHolderBox.Select();
            placeHolderBox.text = "";
        }
        else {
            Debug.Log(www.downloadHandler.text);
            usersSettings.isKeyEntered = true;
            SceneManager.LoadScene(1);
        }
    }
}
