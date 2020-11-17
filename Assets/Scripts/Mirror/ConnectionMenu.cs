using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class ConnectionMenu : MonoBehaviour
{
    [SerializeField] InputField ipInput;

    public void OnClickHost() => NetworkManager.singleton.StartHost();
    public void OnClickConnect()
    {
        NetworkManager.singleton.networkAddress = string.IsNullOrEmpty(ipInput.text) ? "localHost" : ipInput.text;
        NetworkManager.singleton.StartClient();
    }
}
