using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AboutButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button about;

    void TaskOnClick()
    {
        SceneManager.LoadScene("CreditsScreen");
    }
    void Start()
    {
        Button aboutButton = about.GetComponent<Button>();
        aboutButton.onClick.AddListener(TaskOnClick);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
