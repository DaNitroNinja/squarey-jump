using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public int playerScore;
    public int coins = 0;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public GameObject duringGame;
    public Text coinsText;
    public Text coinsTextAtDeath;
    public RawImage background;
    public Text shopText;

    public void Awake()
    {
        //highScoreText.text = PlayerPrefs.GetInt("HighScore",0).ToString();
    }


    void Start()
    {
        // PlayerPrefs.SetInt("Coins",100);

        scoreText.color = Color.white;        

        highScoreText.text = PlayerPrefs.GetInt("HighScore",0).ToString();

        PlayerPrefs.GetInt("Coins",0);

        coinsText.text = PlayerPrefs.GetInt("Coins",0).ToString();

        scoreText.text = playerScore.ToString();

        shopText.text = PlayerPrefs.GetInt("Coins",0).ToString();

        PlayerPrefs.GetString("activeBackground","Default");
    }

[ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        if (playerScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
        }else
        {
            return;
        }
    }

[ContextMenu("Increase Coins")]
        public void addCoins(int coins)
    {
        
        
         PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + coins);
         
         Debug.Log("I have " + PlayerPrefs.GetInt("Coins",0) + " coins");

         coinsText.text = PlayerPrefs.GetInt("Coins",0).ToString(); 

         coinsTextAtDeath.text = PlayerPrefs.GetInt("Coins",0).ToString(); 


    }

[ContextMenu("Reset Game")]
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        gameOverScreen.SetActive(false);

        duringGame.SetActive(true);

    }

    public void gameOver() 
    {
        gameOverScreen.SetActive(true);

        reloadText();

        duringGame.SetActive(false);

    }

    public void FixedUpdate()
    {
        coinsTextAtDeath.text = PlayerPrefs.GetInt("Coins",0).ToString(); 
        if (PlayerPrefs.GetString("activeBackground") == "Default")
        {
            background.color = new Color(226f, 116f, 154f, 1f);

        }else if (PlayerPrefs.GetString("activeBackground") == "Blue")
        {
            background.color = new Color(0f, 229f, 240f, 94f);

        }else if (PlayerPrefs.GetString("activeBackground") == "White")
        {
            background.color = new Color(255f, 255f, 255f, 1f);

        }else if (PlayerPrefs.GetString("activeBackground") == "Black")
        {
            background.color = new Color(0f, 0f, 0f, 1f);
        }else if (PlayerPrefs.GetString("activeBackground") == "Yellow")
        {
           background.color = new Color(255f, 0f, 0f, 1f);
        }else
        {
            Debug.Log("Unable To Display Background, Reverting To Original.");
        }


    }

    public void mainMenu() 
    {
        SceneManager.LoadScene(0);
    }

    [ContextMenu("Reset Coins")]
    public void resetCoins()
    {
        PlayerPrefs.SetInt("Coins",0);
    }

    [ContextMenu("Reset High Score")]
    public void resetHighScore()
    {
        PlayerPrefs.SetInt("HighScore",0);
    }

        public void onPurchaseBlue()
    {
        if (PlayerPrefs.GetInt("Coins",0) >= 25)
        {
            background.color = new Color(0f, 229f, 240f, 94f);

            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins",0) -25);

            shopText.text = PlayerPrefs.GetInt("Coins",0).ToString();

            PlayerPrefs.SetString("activeBackground","Blue");
            
        } else 
        {
            Debug.Log("Insufficient Funds");
        }
        
    }
            public void onPurchaseYellow()
    {
        if (PlayerPrefs.GetInt("Coins",0) >= 50)
        {
            background.color = new Color(255f, 0f, 0f, 1f);

            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins",0) -50);

            shopText.text = PlayerPrefs.GetInt("Coins",0).ToString();

            PlayerPrefs.SetString("activeBackground","Yellow");
            
        } else 
        {
            Debug.Log("Insufficient Funds");
        }
        
    }
            public void onPurchaseWhite()
    {
        if (PlayerPrefs.GetInt("Coins",0) >= 70)
        {
            background.color = new Color(255f, 255f, 255f, 1f);
            
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins",0) -70);

            shopText.text = PlayerPrefs.GetInt("Coins",0).ToString();
            
            PlayerPrefs.SetString("activeBackground","White");
            
        } else 
        {
            Debug.Log("Insufficient Funds");
        }
        
    }
            public void onPurchaseBlack()
    {
        if (PlayerPrefs.GetInt("Coins",0) >= 75)
        {
            background.color = new Color(0f, 0f, 0f, 1f);

            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins",0) -75);

            shopText.text = PlayerPrefs.GetInt("Coins",0).ToString();

            PlayerPrefs.SetString("activeBackground","Black");
            
        } else 
        {
            Debug.Log("Insufficient Funds");
        }
        
    }

           public void onPurchaseDefault()
    {
        if (PlayerPrefs.GetInt("Coins",0) >= 10)
        {
            background.color = new Color(226f, 116f, 154f, 1f);

            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins",0) -10);

            shopText.text = PlayerPrefs.GetInt("Coins",0).ToString();

            PlayerPrefs.SetString("activeBackground","Default");
            
        } else 
        {
            Debug.Log("Insufficient Funds");
        }
        
    }
    

    public void reloadText()
    {
        shopText.text = PlayerPrefs.GetInt("Coins",0).ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore",0).ToString();  
        coinsTextAtDeath.text = PlayerPrefs.GetInt("Coins",0).ToString();
    }



}
