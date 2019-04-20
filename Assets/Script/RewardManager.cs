using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour {

    RewardLocation reward = new RewardLocation();
    int idxCount;
    public Transform Content;
    public GameObject ItemObject;
    public List<RewardItem> ItemList;
    public bool isReward = false;
    private WebViewObject webViewObject;



    // Use this for initialization
    void Start () {
        string url = "133.186.135.41/tourraider_location.php";

        WWWForm form = new WWWForm();
        WWW www = new WWW(url, form);

        StartCoroutine(request(www));


    }
	
	// Update is called once per frame
	void Update () {
        if (isReward){
            Binding();
            isReward = false;
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    public void itemClicked(){




    }




    private void Binding()
    {
        GameObject btnItemTemp;
        ItemScript itemScript;

        foreach (RewardItem item in this.ItemList)
        {

            btnItemTemp = Instantiate(this.ItemObject) as GameObject;
            itemScript = btnItemTemp.GetComponent<ItemScript>();


            itemScript.idx.text = item.idx;
            itemScript.location_name.text = item.name;
            itemScript.Item.onClick = item.OnItemClick;


            btnItemTemp.transform.SetParent(this.Content);
            btnItemTemp.transform.localScale = new Vector3(1, 1, 0);
            
            btnItemTemp.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = item.discount; // 이부분수정
        }
    }



    IEnumerator request(WWW www)
    {
        RewardItem itemTemp;
        int count = 0;
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {

        }
        else
        {
            
            JsonData jsonlist = JsonMapper.ToObject(www.text);
            idxCount = jsonlist["reward"].Count;

            reward.idx = new string[jsonlist["reward"].Count];
            reward.name = new string[jsonlist["reward"].Count];
            reward.treasure_find = new string[jsonlist["reward"].Count];
            reward.latitude = new string[jsonlist["reward"].Count];
            reward.longitude = new string[jsonlist["reward"].Count]; 
            reward.discount_rate = new string[jsonlist["reward"].Count];


            for (int i = 0; i < idxCount; i++)
            {


                reward.idx[i] = jsonlist["reward"][i]["idx"].ToString();
                reward.name[i] = jsonlist["reward"][i]["name"].ToString();
                reward.treasure_find[i] = jsonlist["reward"][i]["treasure_find"].ToString();
                reward.discount_rate[i] = jsonlist["reward"][i]["discount_rate"].ToString();
                reward.latitude[i] = jsonlist["reward"][i]["latitude"].ToString();
                reward.longitude[i] = jsonlist["reward"][i]["longitude"].ToString();


                itemTemp = new RewardItem();

                if (reward.treasure_find[i].Equals("1"))
                {
                    count++;
                    itemTemp.idx = count.ToString();
                    itemTemp.name = reward.name[i];
                    if (int.Parse(reward.discount_rate[i]) > 100)
                    {
                        itemTemp.discount = reward.discount_rate[i] + "원 할인권";
                    }
                    else
                    {
                        itemTemp.discount = reward.discount_rate[i] + "% 할인권";
                    }
                    itemTemp.OnItemClick = new Button.ButtonClickedEvent();
                    //Debug.Log(reward.latitude[i]);
                    itemTemp.OnItemClick.AddListener(delegate { itemClicked(); });

                    isReward = true;
                    this.ItemList.Add(itemTemp);
                }

                Debug.Log(GoResult.count.ToString());


            }
        }
      
    }


}
