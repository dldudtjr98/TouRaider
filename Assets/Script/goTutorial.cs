using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class goTutorial : MonoBehaviour {



    void Start()
    {
      
    }
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
    public void ChangeGameScene()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
