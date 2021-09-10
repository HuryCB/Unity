using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    //resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //references
    public Player player;
    public FloatingTextManager floatingTextManager;
    public int coins;
    public int experience;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }
    public void ShowText(string msg, Vector3 position)
    {
        floatingTextManager.Show(msg, 25, Color.white, position, new Vector3(1,1,0), 0.0f);
    }
    public void SaveState() 
    {

    }

    public void LoadState()
    {
         
    }
}
