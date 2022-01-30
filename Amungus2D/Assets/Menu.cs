using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviourPunCallbacks
{
    [SerializeField] private MenuEntrada _menuEntrada;
    [SerializeField] private MenuLobby _menuLobby;

    private void Start()
    {
        _menuEntrada.gameObject.SetActive(false);
        _menuLobby.gameObject.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        _menuEntrada.gameObject.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        MudaMenu(_menuLobby.gameObject);
        _menuLobby.photonView.RPC("AtualizaLista", RpcTarget.All);
    }

    public void MudaMenu(GameObject menu)
    {
        _menuEntrada.gameObject.SetActive(false);
        _menuLobby.gameObject.SetActive(false);

        menu.SetActive(true);
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        _menuLobby.AtualizaLista();
    }

    public void SairDoLobby()
    {
        NetworkManager.Instance.SairDoLobby();
        MudaMenu(_menuEntrada.gameObject);
    }

    [PunRPC]
    public void ComecaJogo(string nomeCena)
    {
        PhotonNetwork.LoadLevel(nomeCena);
    }
}
