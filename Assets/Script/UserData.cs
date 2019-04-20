using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData{
    static int collectedTreasure = 0;

    public static int CollectedTreasure
    {
        get
        {
            //collectedTreasure = PlayerPrefs.GetInt("treasure");
            return collectedTreasure;
        }

        set
        {
            collectedTreasure = value;
            //PlayerPrefs.SetInt("treasure" , collectedTreasure);
        }
    }
}
