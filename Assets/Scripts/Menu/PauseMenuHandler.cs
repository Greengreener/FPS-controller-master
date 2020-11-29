using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] bool paused = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject hud;
    [SerializeField] Gun_Main gunScript;


    private void Start()
    {
        pauseMenu.SetActive(false);
        gunScript = FindObjectOfType<Gun_Main>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            pauseMenu.SetActive(true);
            hud.SetActive(false);
            Time.timeScale = 0;
            paused = true;
            gunScript.enabled = false;
            //Onlock the cursor
            Cursor.lockState = CursorLockMode.None;
            //Show the cursor
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            pauseMenu.SetActive(false);
            hud.SetActive(true);
            Time.timeScale = 1;
            paused = false;
            gunScript.enabled = true;
            //Lock the cursor
            Cursor.lockState = CursorLockMode.Locked;
            //Hide the cursor
            Cursor.visible = false;

        }
    }
    public void SetSubMenuOnOff(GameObject _subMenu)
    {
        _subMenu.SetActive(!_subMenu.activeSelf);
    }
}
