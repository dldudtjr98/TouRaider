using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelExit : MonoBehaviour {

    public GameObject HintPanel;
    public Button ShowHint;


    // Use this for initialization
    void Start () {
        if(HintPanel.activeSelf == true) Visible();
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    public void Invisible(){
        HintPanel.SetActive(false);
        ShowHint.gameObject.SetActive(true);
        Debug.Log("invisible");
    }

    public void Visible(){
        HintPanel.SetActive(true);
        ShowHint.gameObject.SetActive(false);
        Debug.Log("visible");
    }



}
