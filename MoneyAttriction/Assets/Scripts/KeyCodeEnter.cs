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
    private float screenX = Screen.width;
    private float screenY = Screen.height;


    struct SettingsStruct
    {
        public bool keyBool;
    }
    struct CheckAnswer
    {
        public string message;
        public int status;
    }
private void Awake()
    {
        if (PlayerPrefs.HasKey("settingsS"))
        {
            SettingsStruct loadSettings = JsonUtility.FromJson<SettingsStruct>(PlayerPrefs.GetString("settingsS"));
            bool isKeyEntered = loadSettings.keyBool;

            if (isKeyEntered)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
    public void EnterKey()
    {
        string deviceID = SystemInfo.deviceUniqueIdentifier;
        StartCoroutine(SendKeyToServer(deviceID, keyText.text));
    }

    private IEnumerator SendKeyToServer(string deviceID, string keyCode)
    {
        SettingsStruct setSettings = new SettingsStruct();
        UnityWebRequest www = UnityWebRequest.Get($"http://ngmschool.pserver.ru/check?key={keyCode}&device={deviceID}");
        yield return www.SendWebRequest();
        CheckAnswer checkAnswer = JsonUtility.FromJson<CheckAnswer>(www.downloadHandler.text);

        if (www.result != UnityWebRequest.Result.Success || checkAnswer.status == 404)
        {
            placeHolderBox.GetComponent<Image>().color = new Color(1, 0.627451f, 0.627451f, 1);
            yield return new WaitForSecondsRealtime(0.5f);
            placeHolderBox.GetComponent<Image>().color = Color.white;
            placeHolderBox.Select();
            placeHolderBox.text = "";
        }
        else
        {
            setSettings.keyBool = true;
            PlayerPrefs.SetString("settingsS", JsonUtility.ToJson(setSettings));
            SceneManager.LoadScene(1);
        }
    }
}
