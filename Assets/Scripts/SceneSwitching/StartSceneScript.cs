using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Two) && OVRInput.GetDown(OVRInput.Button.One)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
