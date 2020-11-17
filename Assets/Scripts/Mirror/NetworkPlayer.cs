using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class NetworkPlayer : NetworkBehaviour
{
    [SyncVar]
    public string _userName = "Blayer";

    [SerializeField] GameObject lobbyPlayer;
    [SerializeField] GameObject gameplayPlayer;

    private bool connectedToLobbyUi = false;
    private LobbyMenu lobby;
    public override void OnStartLocalPlayer()
    {
        SceneManager.LoadSceneAsync("Lobby", LoadSceneMode.Additive);
    }
    void Start()
    {
        lobbyPlayer.SetActive(true);
        gameplayPlayer.SetActive(false);
    }
    private void Update()
    {
        if (lobby == null && lobbyPlayer.activeSelf)
            lobby = FindObjectOfType<LobbyMenu>();
        if (!connectedToLobbyUi && lobby != null)
        {
            lobby.OnPlayerConnect(this);
            connectedToLobbyUi = true;
        }
    }
    [Command] public void CmdReadyPlayer(int _index, bool _isReady) => RpcReadyPlayer(_index, _isReady);
    [ClientRpc] public void RpcReadyPlayer(int _index, bool _isReady) => lobby?.SetReadyPlayer(_index, _isReady);

    [Command] public void CmdSetPlayerName(string _name) => RpcSetPlayerName(_name);
    [ClientRpc] public void RpcSetPlayerName(string _name) => _userName = _name;

    [Command] public void CmdStartGame() => RpcStartGame();
    [ClientRpc]
    public void RpcStartGame()
    {
        NetworkPlayer[] players = FindObjectsOfType<NetworkPlayer>();
        foreach (NetworkPlayer player in players)
        {
            player.lobbyPlayer.SetActive(false);
            player.gameplayPlayer.SetActive(true);
            if (player.isLocalPlayer)
            {
                SceneManager.UnloadSceneAsync("Lobby");
                SceneManager.LoadSceneAsync("Gameplay01", LoadSceneMode.Additive);

                //Start the FPS Controller here
            }
        }
    }
    public void ReadyPlayer(int _index, bool _isReady)
    {
        if (isLocalPlayer) CmdReadyPlayer(_index, _isReady);
    }
    public void SetName(string _name)
    {
        if (isLocalPlayer) CmdSetPlayerName(_name);
    }
    public void StartGame()
    {
        if (isLocalPlayer) CmdStartGame();
    }
}
