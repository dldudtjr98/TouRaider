using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Messaging;
using UnityEngine.SceneManagement;

public class HintManager : MonoBehaviour {
    public double hintlatitude;
    public double hintlongitude;
    public Text hintText;
    bool LocationBool = false;
    string OneHint = "상가마을의 힌트입니다";
    string TwoHint = "민속마을의 힌트입니다";
    string ThreeHint = "장터의 힌트입니다";
    string FourHint = "놀이마을의 힌트입니다";
    string NoHint = "아직 보물의 근처가 아닙니다";

    public static int zone = 1;

    void Start()
    {
        StartCoroutine(LocationServiceStart());

       
    }

    // Update is called once per frame
    void Update () {
        if (LocationBool)
        {           

            if(hintlatitude < 37.259 && hintlatitude > 37.257 && hintlongitude < 127.118 && hintlongitude > 127.116){
                hintText.text = OneHint;
                zone = 1;
            }

            else if (hintlatitude < 37.261 && hintlatitude > 37.259 && hintlongitude < 127.122 && hintlongitude > 127.120)
            {
                hintText.text = TwoHint;
                zone = 2;
            }


            else if (hintlatitude < 37.261 && hintlatitude > 37.259 && hintlongitude < 127.124 && hintlongitude > 127.122)
            {
                hintText.text = ThreeHint;
                zone = 3;
            }


            else if (hintlatitude < 37.258 && hintlatitude > 37.256 && hintlongitude < 127.119 && hintlongitude > 127.117)
            {
                hintText.text = FourHint;
                zone = 4;
            }

            else {
                hintText.text = NoHint;
            }

            LocationBool = false;
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main");
            }
        }

    }


    IEnumerator LocationServiceStart()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            //hintText.text = Input.location.lastData.latitude.ToString() + Input.location.lastData.longitude.ToString();
            LocationBool = true;
            hintlatitude = Input.location.lastData.latitude;
            hintlongitude = Input.location.lastData.longitude;
        }

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
    }


}
