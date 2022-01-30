using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuEntrada : MonoBehaviour
{
    [SerializeField]private Text nomeDoJogador;
    [SerializeField]private Text nomeDaSala;

    public void CriaSala()
    {
        NetworkManager.Instance.MudaNick(nomeDoJogador.text);
        NetworkManager.Instance.CriaSala(nomeDaSala.text);
    }

    public void EntraSala()
    {
        NetworkManager.Instance.MudaNick(nomeDoJogador.text);
        NetworkManager.Instance.EntraSala(nomeDaSala.text);
    }
}
