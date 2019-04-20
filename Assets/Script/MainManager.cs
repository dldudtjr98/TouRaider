using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {
    public GameObject checkPrefab;
    public static int[] zoneCount = new int[4];


    // Use this for initialization
    void Start ()
    {
       // zoneCount[0]++;
    }
	
	// Update is called once per frame
	void Update () {
        int cnt = 0;

        for (int i = 1; i <= 4; i++)
        {
            GameObject.Find("zone" + i + "Count").GetComponent<Text>().text = zoneCount[i-1].ToString() + "/3";
            if (zoneCount[i-1] == 3)
                cnt++;
        }

        UserData.CollectedTreasure = cnt;

        for (int i = 1; i <= UserData.CollectedTreasure; i++)
        {
            GameObject obj = Instantiate(checkPrefab, GameObject.Find("Treasure_" + i).transform);
            obj.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
