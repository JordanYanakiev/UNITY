using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public Button howToPlay;

    void HowToPlayGame()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    // Start is called before the first frame update
    void Start()
    {
        Button howTo = howToPlay.GetComponent<Button>();
        howTo.onClick.AddListener(HowToPlayGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
