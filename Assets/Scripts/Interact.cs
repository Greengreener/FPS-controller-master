using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    Gun _gunScript;
    Camera _mainCamera;

    float _range = 10f;
    void Start()
    {
        _mainCamera = Camera.main;
        _gunScript = gameObject.GetComponentInChildren<Gun>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerInteract();
        }
    }
    void PlayerInteract()
    {
        RaycastHit interact;
        ObjectInfo hitInfo;
        if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out interact, _range))
        {
            hitInfo = interact.transform.GetComponent<ObjectInfo>();
            Debug.Log(interact.ToString());
            if (hitInfo.isAmmo)
            {
                if (_gunScript.ammo >= _gunScript.ammoMax)
                {
                    return;
                }
                if (_gunScript.ammo + hitInfo.AmmoAmount > _gunScript.ammoMax)
                {
                    _gunScript.ammo = _gunScript.ammoMax;
                }
                else
                {
                    _gunScript.ammo += hitInfo.AmmoAmount;
                }
                _gunScript.UIUpdate();
                hitInfo.gameObject.SetActive(false);
            }
        }
    }
}
