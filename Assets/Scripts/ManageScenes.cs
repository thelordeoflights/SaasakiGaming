using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
