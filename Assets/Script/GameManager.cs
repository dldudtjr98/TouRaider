using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;


public class GameManager : MonoBehaviour {
    public GameObject arCamera;
    public GameObject TreasurePrefab;


    // Use this for initialization
    void Start () {
        VuforiaRuntime.Instance.InitVuforia();
        Transform[] childs = arCamera.GetComponentsInChildren<Transform>();

        for (int i = 0; i < childs.Length; i++)
        {
            if (childs[i].name != "BackgroundPlane" && childs[i].name != "test5")
            {
                GameObject newTreasuer = Instantiate(TreasurePrefab);

                newTreasuer.transform.SetParent(childs[i]);
            }
        }
        GameObject background = GameObject.Find("BackgroundPlane");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
