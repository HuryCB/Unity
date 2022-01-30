using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviourPunCallbacks
{
    public static GameController Instance { get; private set; }
    public List<ControleJogador> Jogadores { get => _jogadores;private set => _jogadores = value; }

    [SerializeField] private string _localizaoPrefab;
    [SerializeField] private Transform[] _spawns;

    private int _jogadoresEmJogo = 0;
    private List<ControleJogador> _jogadores;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            gameObject.SetActive(false);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [PunRPC]
    private void AdicionaJogador()
    {
        _jogadoresEmJogo++;
        if(_jogadoresEmJogo == PhotonNetwork.PlayerList.Length)
        {
            CriaJogador();
        }
    }
    private void Start()
    {
        photonView.RPC("AdicionaJogador", RpcTarget.AllBuffered);
        _jogadores = new List<ControleJogador>();
    }
    private void CriaJogador()
    {
        var jogadorObj = PhotonNetwork.Instantiate(_localizaoPrefab, _spawns[Random.Range(0, _spawns.Length)].position, Quaternion.identity);
        var jogador = jogadorObj.GetComponent<ControleJogador>();

        jogador.photonView.RPC("Inicializa", RpcTarget.All, PhotonNetwork.LocalPlayer);
    }
}
