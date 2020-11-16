using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    GameObject _flagSystemHolder;
    FlagSystem _flagSystem;

    GameObject playerFlag;
    public bool hasFlag;
    public bool RedTeam, BlueTeam;
    public Image flagIcon;
    private void Start()
    {
        _flagSystemHolder = GameObject.FindGameObjectWithTag("Flag");
        _flagSystem = _flagSystemHolder.GetComponent<FlagSystem>();
        playerFlag = GameObject.Find("PlayerFlag");
        playerFlag.gameObject.SetActive(false);
        hasFlag = false;
        flagIcon.gameObject.SetActive(false);
    }
    public void GetFlag()
    {
        hasFlag = true;
        playerFlag.SetActive(true);
        flagIcon.gameObject.SetActive(true);
    }
    public void LoseFlag()
    {
        hasFlag = false;
        playerFlag.SetActive(false);
        flagIcon.gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RedFlagBase" && RedTeam && hasFlag)
        {
            _flagSystem.RedTeamPoints++;
            _flagSystem.ResetFlag();
            LoseFlag();
        }
        if (other.gameObject.tag == "BlueFlagBase" && BlueTeam && hasFlag)
        {
            _flagSystem.BlueTeamPoints++;
            _flagSystem.ResetFlag();
            LoseFlag();
        }
    }
}
