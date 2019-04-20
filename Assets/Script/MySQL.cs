using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySQL {



    public static IEnumerator AddLocation(double latitude, double longitude)
    {
        string URL = "133.186.135.41/tourraider.php";

        WWWForm form = new WWWForm();
        form.AddField("latitude", latitude.ToString());
        form.AddField("longitude", longitude.ToString());
        form.AddField("user_id", "0");
        form.AddField("datetime", System.DateTime.Now.ToString());
        form.AddField("zone", "1");

        /*
        if(놀이마을(국가박물관)){
            form.AddField("zone", 1);
        }

        */
        Debug.Log(System.DateTime.Now.ToString());

        WWW request = new WWW(URL, form);
        Debug.Log(request);

        Debug.Log("end");
 //       yield return request;

        yield return null;
    }
}
