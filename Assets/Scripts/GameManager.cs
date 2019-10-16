using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public PlayerController pController;
    public enum Mode { Explore, Shooting }
    public Mode actualMode;

    public GameObject camPlayer;
    public GameObject camExplore;
    public float yOffset;
    public float zOffset;

    bool explore = true;

    public UnityEvent OnExplore;
    public UnityEvent OnShooting;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SwitchMode();
        }

        if (!explore) {
            //Vector3 playerForward = pController.transform.forward;
            //Vector3 dir = ((camPlayer.transform.position + playerForward) - camPlayer.transform.position).normalized;
            //pController.transform.forward = dir;
        }
    }

    public void SwitchMode() {

        if (explore) {
            OnExplore?.Invoke();
            //camPlayer.SetActive(true);
            //camExplore.SetActive(false);
        }

        else
        {
            OnShooting?.Invoke();
            //camPlayer.SetActive(false);
            //camExplore.SetActive(true);
        }
        Debug.Log(this.name);

        explore = !explore;
    }

    public void ResetPlayerCameraPosition() {
        Transform playerTransform = pController.transform;
        Vector3 pos = playerTransform.position - playerTransform.forward * zOffset - playerTransform.up * yOffset;
        camPlayer.transform.position = pos;
        camPlayer.transform.forward = pController.transform.forward;
    }
}
