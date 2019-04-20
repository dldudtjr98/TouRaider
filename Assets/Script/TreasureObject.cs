using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TreasureObject : MonoBehaviour {
    public GameObject openPrefab;

    public bool isDone = false;

    IEnumerator LocationServiceStart()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location
        Input.location.Start();

//        System.DateTime.Now;

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
            isDone = true;
            yield return StartCoroutine(MySQL.AddLocation(Input.location.lastData.latitude, Input.location.lastData.longitude));
        }
        Input.location.Stop();

        yield return new WaitForSeconds(3.0f);
    }

	// Use this for initialization
	void Start ()
    {
        //GetComponent<Renderer>().material.color = Color.red;
    }
	
	// Update is called once per frame
	void Update () {
        if(isDone)
            SceneManager.LoadScene("Main");
    }

    private void OnMouseDown()
    {
        GameObject open = Instantiate(openPrefab);
        GetComponent<SpriteRenderer>().sprite = openPrefab.GetComponent<SpriteRenderer>().sprite;
        Destroy(open);

        string hint = GameObject.Find("Hint").GetComponent<Text>().text;

//        PlayerPrefs.SetInt("zone" + HintManager.zone.ToString() , PlayerPrefs.GetInt("zone`"))
        MainManager.zoneCount[HintManager.zone - 1]++;
                                //UserData.CollectedTreasure += 1;
        StartCoroutine(LocationServiceStart());
    }
}
