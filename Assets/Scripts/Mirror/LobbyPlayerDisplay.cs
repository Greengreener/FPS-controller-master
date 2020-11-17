using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyPlayerDisplay : MonoBehaviour
{
    public bool Filled { get { return button.interactable; } }
    public bool Ready { get; private set; } = false;

    [SerializeField] Text playerName;
    [SerializeField] Button button;
    [SerializeField] Image readyIndicator;
    [SerializeField] Color readyColor = Color.green;
    [SerializeField] Color notReadyColor = Color.red;

    NetworkPlayer player;
    int index;

    public void AssignPlayer(NetworkPlayer _player, int _index)
    {
        player = _player;
        index = _index;
        button.interactable = true;
    }
    public void TogglePlayerReadyState()
    {
        SetReadyState(!Ready);
        player.ReadyPlayer(index, Ready);
    }
    public void SetReadyState(bool _isReady) => Ready = _isReady;
    private void Start()
    {
        button.interactable = false;
    }
    private void Update()
    {
        playerName.text = player != null && !string.IsNullOrEmpty(player._userName) ? player._userName : "Blayer";
        readyIndicator.color = Ready ? readyColor : notReadyColor;
    }
}
