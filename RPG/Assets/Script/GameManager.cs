using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }
    //resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;
    //references
    public Player player;
    //public Weapon weapon;
    public int pesos;
    public int experience;

    //Save State
    /*
     * int prefered Skin
     * int pesos
     * int experience
     * int weapon level
     * 
     */
    public void SaveState()
    {

    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
       
    }
    /*
    public void SaveState( )
    {
        string s = "";
        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";
        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState()
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }
        string[] data = PlayerPrefs.GetString("SaveSate").Split('|');
        //change playerSking
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        //change the weapon level

    }
    */
}