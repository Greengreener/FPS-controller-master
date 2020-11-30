using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagSystem : MonoBehaviour
{
    /// <summary>
    /// The ID for the team
    /// </summary>
    public int teamId;
    /// <summary>
    /// The spawn location for the flag
    /// </summary>
    public Vector3 orignalLocation;
    GameObject _flagMesh;
    Collider flagZone;
    /// <summary>
    /// The UI display for the teams score
    /// </summary>
    public Text redTeamPoints;
    /// <summary>
    /// The UI display for the teams score
    /// </summary>
    public Text blueTeamPoints;
    public int RedTeamPoints { get; set; }
    /// <summary>
    /// the Score for the Red team
    /// </summary>
    public int _redTeamPoints;
    public int BlueTeamPoints { get; set; }
    /// <summary>
    /// The Score for the Blue teams
    /// </summary>
    int _blueTeamPoints;

    void Start()
    {
        orignalLocation = transform.position;
        _flagMesh = GameObject.Find("Pole");
        ResetFlag();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Flag.Capture");
        _flagMesh.SetActive(false);
        PlayerInfo playerInfo = other.GetComponent<PlayerInfo>();
        playerInfo.GetFlag();
    }
    /// <summary>
    /// Resets the flag position when the flag is collected at home base
    /// </summary>
    public void ResetFlag()
    {
        Debug.Log("FlagReset");
        _flagMesh.SetActive(true);
        // _redTeamPoints = RedTeamPoints;
        // _blueTeamPoints = BlueTeamPoints;
        // redTeamPoints.text = _redTeamPoints + " :   RED TEAM";
        // blueTeamPoints.text = _blueTeamPoints + " : BLUE TEAM";
    }
}
