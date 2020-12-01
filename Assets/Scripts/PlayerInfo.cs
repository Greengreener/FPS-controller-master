using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health), typeof(Movement))]
public class PlayerInfo : MonoBehaviour
{
    /// <summary>
    /// Reference to the Game Flag system holder
    /// </summary>
    GameObject _flagSystemHolder;
    /// <summary>
    /// Reference to the Game Flag system
    /// </summary>
    public FlagSystem _flagSystem;
    /// <summary>
    /// Reference to the Flag object on the player
    /// </summary>
    public GameObject playerFlag;
    /// <summary>
    /// Bool if the player has the flag
    /// </summary>
    public bool hasFlag;
    /// <summary>
    /// Bool for the team of the player
    /// </summary>
    public bool RedTeam, BlueTeam;
    /// <summary>
    /// Hud icon for if the player has the flag
    /// </summary>
    public Image flagIcon;
    void Start()
    {
        _flagSystemHolder = GameObject.FindGameObjectWithTag("Flag");
        _flagSystem = _flagSystemHolder.GetComponent<FlagSystem>();
        playerFlag.gameObject.SetActive(false);
        hasFlag = false;
        flagIcon.gameObject.SetActive(false);
    }
    /// <summary>
    /// Called if player gets flag
    /// </summary>
    public void GetFlag()
    {
        hasFlag = true;
        playerFlag.SetActive(true);
        flagIcon.gameObject.SetActive(true);
    }
    /// <summary>
    /// Called if player loses flag
    /// </summary>
    public void LoseFlag()
    {
        hasFlag = false;
        playerFlag.SetActive(false);
        flagIcon.gameObject.SetActive(false);
    }
    /// <summary>
    /// Dectects if flag collection if player has flag
    /// </summary>
    /// <param name="other"> The trigger for the player team home</param>
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
