using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager Instance { get; private set; }
    private void Awake()
    {
        /*if(Instance != null && Instance != this)
         * {
            gameObject.setActive(false);
            return;
            }
        */

        if(Instance == null)
        {
            Instance = this;
        }
  
        DontDestroyOnLoad(gameObject);     
    }

    public void CriaSala(string text)
    {
        PhotonNetwork.CreateRoom(text);
    }

    public void EntraSala(string text)
    {
        PhotonNetwork.JoinRoom(text);
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conexão bem sucedida");
    }

    public void MudaNick(string nickname)
    {
        PhotonNetwork.NickName = nickname;
    }

    public string ObterListaDeJogadores()
    {
        var lista = "";
        foreach(var player in PhotonNetwork.PlayerList)
        {
            lista += player.NickName + "\n";
        }

        return lista;
    }

    internal void ComecaJogo(string nomeCena)
    {
        NetworkManager.Instance.photonView.RPC("ComecaJogo", RpcTarget.All, nomeCena);
    }

    internal void SairDoLobby()
    {
        PhotonNetwork.LeaveRoom();
    }

    public bool DonoDaSala()
    {
        return PhotonNetwork.IsMasterClient;
    }
}
