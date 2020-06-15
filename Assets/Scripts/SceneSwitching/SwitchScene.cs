using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void GoToScene(int i)
    {
        SceneManager.LoadSceneAsync(i);
    }

    public void Quit()
    {
        Application.Quit();
    } 
}
