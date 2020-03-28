using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    public Button exitGame;

    void TaskOnClick()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        Button exit = exitGame.GetComponent<Button>();
        exit.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
