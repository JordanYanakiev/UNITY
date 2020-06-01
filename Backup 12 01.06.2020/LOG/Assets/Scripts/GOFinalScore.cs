using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GOFinalScore : MonoBehaviour
{
    // Start is called before the first frame update
    Text score;
    public Text highScore;
    int intScore = 0;
    int coins;
    public Text money;

    void UpdateCoins()
    {
        coins = PlayerPrefs.GetInt("Coins");
        coins = coins + intScore;
        PlayerPrefs.SetInt("Coins", coins);
        Debug.Log(coins);
    }

    void Start()
    {
        score = GetComponent<Text>();
        //Show the High Score to the high Score field
        highScore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();

        
        ////Update the money owned
        //Text moneyOwned = GetComponent<Text>();
        //money.text = PlayerPrefs.GetInt("Money", 0).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        intScore = PlayerMove.result;
        score.text = "Final Score: " + intScore;
        highScore.text = "High Score: " + PlayerPrefs.GetInt("Highscore").ToString();

        //Save the result in a file as a High Score
        if (intScore > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", intScore);
        }
    }
}
