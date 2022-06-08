using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject gameoverText;

    public bool isgameover;
    // Start is called before the first frame update
    void Start()
    {
        isgameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isgameover)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            finishgame();
        }
    }

    public void EndGame()
    {
        isgameover = true;
        gameoverText.SetActive(true);
    }

    public void finishgame()
    {
        Application.Quit();
    }
}
