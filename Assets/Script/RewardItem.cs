using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class RewardItem{

    public string idx;
    public string name;
    public string discount;

    public Button.ButtonClickedEvent OnItemClick;

}
