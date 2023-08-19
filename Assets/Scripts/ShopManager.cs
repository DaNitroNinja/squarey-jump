using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    public Text coinsText;
    public Camera mainCamera;
    public RawImage background;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("Coins",0);
        coinsText.text = PlayerPrefs.GetInt("Coins",0).ToString();
        background = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = PlayerPrefs.GetInt("Coins",0).ToString();

    }

    public void onPurchaseBlue()
    {
        if (PlayerPrefs.GetInt("Coins",0) >= 25)
        {
            background.color = new Color(0, 229, 240, 94);
            PlayerPrefs.SetInt("Coins", -25);
        } else 
        {
            Debug.Log("Insufficient Funds");
        }
        
    }
        public void onPurchaseDefault()
    {
        if (PlayerPrefs.GetInt("Coins",0) >= 10)
        {
            background.color = new Color(226, 116, 154, 1);
            PlayerPrefs.SetInt("Coins", -10);
        } else 
        {
            Debug.Log("Insufficient Funds");
        }
        
    }
}
