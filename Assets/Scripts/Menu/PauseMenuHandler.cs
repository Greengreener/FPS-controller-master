using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] bool paused = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject hud;
    [SerializeField] Gun_Main gunScript;
    [SerializeField] List<GameObject> crossHair;
    [SerializeField] int crossHairId;

    [SerializeField] List<GameObject> subMenus;
    private void Start()
    {
        pauseMenu.SetActive(false);
        gunScript = FindObjectOfType<Gun_Main>();
        crossHair = new List<GameObject>(GameObject.FindGameObjectsWithTag("CrossHair"));
        for (int i = 0; i > crossHair.Count; i++) { crossHair[i].SetActive(false); }
        crossHair[0].SetActive(true);
        crossHairId = 0;
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
            for (int i = 0; i < subMenus.Count; i++)
            {
                subMenus[i].SetActive(false);
                print("turned off " + i);
            }
        }
    }
    public void SetSubMenuOnOff(GameObject _subMenu)
    {
        _subMenu.SetActive(!_subMenu.activeSelf);
    }
    public void ChangeCrossHair()
    {
        crossHair[crossHairId].SetActive(false);
        crossHairId++;
        if (crossHairId >= crossHair.Count)
        {
            crossHairId = 0;
        }
        crossHair[crossHairId].SetActive(true);
    }
}
