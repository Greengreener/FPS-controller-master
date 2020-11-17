using UnityEngine;
using UnityEngine.UI;

public class LobbyMenu : MonoBehaviour
{
    [SerializeField] LobbyPlayerDisplay[] playerDisplays;
    [SerializeField] Button startButton;
    [SerializeField] Button readyButton;
    [SerializeField] InputField playerNameInput;

    GameNetworkManager network;
    NetworkPlayer localPlayer;

    public void OnPlayerConnect(NetworkPlayer player)
    {
        for (int i = 0; i < playerDisplays.Length; i++)
        {
            LobbyPlayerDisplay display = playerDisplays[i];
            if (!display.Filled)
            {
                display.AssignPlayer(player, i);
                if (player.isLocalPlayer)
                {
                    localPlayer = player;
                    readyButton.onClick.AddListener(display.TogglePlayerReadyState);
                }
                break;
            }
        }
    }
    public void OnClickStart() => localPlayer.StartGame();
    public void SetReadyPlayer(int _index, bool _isReady) => playerDisplays[_index].SetReadyState(_isReady);
    private void Start()
    {
        network = GameNetworkManager.singleton as GameNetworkManager;
        playerNameInput.onEndEdit.AddListener(OnEndEditName);
        startButton.interactable = false;
    }
    private void OnEndEditName(string _name)
    {
        if (localPlayer != null)
        {
            localPlayer.SetName(_name);
        }
    }
    private void Update()
    {
        if (network.IsHost)
        {
            foreach (LobbyPlayerDisplay display in playerDisplays)
            {
                if (!display.Ready && display.Filled)
                {
                    if (startButton.interactable)
                    {
                        startButton.interactable = false;
                    }
                    return;
                }
            }
            if (!startButton.interactable) startButton.interactable = true;
        }
    }
}
