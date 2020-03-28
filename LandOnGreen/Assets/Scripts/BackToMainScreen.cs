using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackToMainScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public Button back;

    void TaskOnClick()
    {
        SceneManager.LoadScene("StartScreen");
    }
    void Start()
    {
        Button backToMain = back.GetComponent<Button>();
        backToMain.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
