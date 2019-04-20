using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GoResult : MonoBehaviour {

    private bool isFind = false;
    public static int count = 0;
    public GameObject panel;

    // Use this for initialization
    void Start () {

       
	}
	
	// Update is called once per frame
	void Update () {
        /*
        for (int i = 1; i <= UserData.CollectedTreasure; i++)
        {
            if(GameObject.Find("Treasure_" + i).transform.childCount > 0)
            {
                isFind = true;
                count++;
            }
            
        }*/
        count = UserData.CollectedTreasure;
    }

   


    public void ChangeScene()
    {
        if (count > 0)
        {
            PlayerPrefs.SetInt("treasure", 0);
            SceneManager.LoadScene("Result");
        }

        else{
            panel.SetActive(true);
        }
    }
}
