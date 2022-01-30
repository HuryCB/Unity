using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLobby : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text _listaDeJogadores;
    [SerializeField] private Button _comecaJogo;

    [PunRPC]
    public void AtualizaLista()
    {
        _listaDeJogadores.text = NetworkManager.Instance.ObterListaDeJogadores();
        _comecaJogo.interactable = NetworkManager.Instance.DonoDaSala();
    }
}
