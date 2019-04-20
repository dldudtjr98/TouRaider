using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureCount : MonoBehaviour {

    public Text text;
    

    // Use this for initialization
    void Start () {
        text.text = "총 " + GoResult.count.ToString() + " 개의";

    }
	
	// Update is called once per frame
	void Update () {
       
    }
}
