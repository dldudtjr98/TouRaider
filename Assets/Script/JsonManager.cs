using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;


public class JsonManager : MonoBehaviour {


    Data data = new Data();
    
    

    // Use this for initialization
    void Start () {
        string url = "133.186.135.41/tourraider_get.php";

        WWWForm form = new WWWForm();
        WWW www = new WWW(url, form);

        StartCoroutine(request(www));

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator request(WWW www)
    {

        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            
        }
        else
        {
            
            JsonData jsonlist = JsonMapper.ToObject(www.text);

            Debug.Log(jsonlist["userData"].Count);

            data.idx = new string[jsonlist["userData"].Count];
            data.latitude = new string[jsonlist["userData"].Count];
            data.longitude = new string[jsonlist["userData"].Count];
            data.create_date = new string[jsonlist["userData"].Count];
            data.zone = new string[jsonlist["userData"].Count];


            for (int i = 0; i < jsonlist["userData"].Count; i++)
            {
                

                data.idx[i] = jsonlist["userData"][i]["idx"].ToString();
                data.latitude[i] = jsonlist["userData"][i]["latitude"].ToString();
                data.longitude[i] = jsonlist["userData"][i]["longitude"].ToString();
                data.create_date[i] = jsonlist["userData"][i]["create_date"].ToString();
                data.zone[i] = jsonlist["userData"][i]["zone"].ToString();
                

                
            }
            
        }
    }

}
