using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkPlayerIntitaializer : NetworkBehaviour
{
    [SerializeField] GameObject playerCamera;
    [SerializeField] GameObject playerCanvas;
    [SerializeField] CameraLook cameraBody;
    [SerializeField] GameObject playerGun;
    public override void OnStartAuthority()
    {
        GetComponentInChildren<PlayerInfo>().enabled = true;
        GetComponentInChildren<Movement>().enabled = true;
        cameraBody.enabled = true;
        playerCamera.SetActive(true);
        playerCanvas.SetActive(true);
        playerGun.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
