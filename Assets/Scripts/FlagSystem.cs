using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagSystem : MonoBehaviour
{
    [SerializeField] int teamId;
    public Vector3 orignalLocation;
    GameObject _flagMesh;
    Collider flagZone;
    public Text redTeamPoints;
    public Text blueTeamPoints;


    public int RedTeamPoints { get; set; }
    public int _redTeamPoints;
    public int BlueTeamPoints { get; set; }
    int _blueTeamPoints;

    // Start is called before the first frame update
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
    public void ResetFlag()
    {
        Debug.Log("FlagReset");
        _flagMesh.SetActive(true);
        _redTeamPoints = RedTeamPoints;
        _blueTeamPoints = BlueTeamPoints;
        redTeamPoints.text = _redTeamPoints + " :   RED TEAM";
        blueTeamPoints.text = _blueTeamPoints + " : BLUE TEAM";
    }
}
