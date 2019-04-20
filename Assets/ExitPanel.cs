using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanel : MonoBehaviour {

    public GameObject panel;

	// Use this for initialization
	void Start () {
        panel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Invisible()
    {

        panel.SetActive(false);

    }
}
