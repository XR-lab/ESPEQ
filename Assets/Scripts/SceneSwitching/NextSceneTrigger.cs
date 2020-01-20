using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneTrigger : MonoBehaviour {
    
    public void TriggerNextScene() {
        SceneSwitcher.Instance?.GoToNextScene();
    }
}
