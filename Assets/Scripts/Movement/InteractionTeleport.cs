using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTeleport : MonoBehaviour {

    [SerializeField] private Transform _destination;

    public void Teleport() {
        StartCoroutine(TeleportRoutine(GameObject.FindWithTag("Player").transform));
    }

    private IEnumerator TeleportRoutine(Transform player) {
        OVRScreenFade fade = player.GetComponentInChildren<OVRScreenFade>();
        fade.FadeOut();
        yield return new WaitForSeconds(fade.fadeTime);
        player.position = _destination.position;
        fade.FadeIn();
    }

}
