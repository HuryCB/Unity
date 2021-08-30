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
            Destroy(player.gameObject);
            Destroy(floatingTextManager.gameObject);
            Destroy(hud);
            Destroy(menu);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    //resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;
    //references
    public Player player;
    public Weapon weapon;
    public FloatingTextManager floatingTextManager;
    public RectTransform hitpointBar;
    public int pesos;
    public int experience;
    public GameObject hud;
    public GameObject menu;

    //Save State
    /*
     * int prefered Skin
     * int pesos
     * int experience
     * int weapon level
     * 
     */

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    //Upgrade Weapon
    public bool TryUpgradeWeapon()
    {
        //is the weapon max leve?
        if(weaponPrices.Count <= weapon.weaponLevel)
        {
            return false;
        }

        if(pesos >= weaponPrices[weapon.weaponLevel])
        {
            pesos -= weaponPrices[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }

        return false;
    }

    //HitPoint Bar
    public void OnHitpoitChange()
    {
        float ratio = (float)player.hitpoint / (float)player.maxHitpoint;
        hitpointBar.localScale = new Vector3(1, ratio, 1);
    }
    private void Update()
    {
        GetCurrentLevel();
    }

    public int GetXpToLevel(int level)
    {
        int r = 0;
        int xp = 0;

        while(r < level)
        {
            xp += xpTable[r];
            r++;
        }
        return xp;
    }
    public int GetCurrentLevel()
    {
        int r = 0;
        int add = 0;

        while(experience >= add)
        {
            add += xpTable[r];
            r++;

            if(r == xpTable.Count)//Max Level
            {
                return r;
            }
        }

        return r;
    }

    public void GrantXp(int xp)
    {
        int currentLevel = GetCurrentLevel();
        experience += xp;
        if(currentLevel < GetCurrentLevel())
        {
            OnLevelUp();
        }
    }

    public void OnLevelUp()
    {
        player.OnLevelUp();
        OnHitpoitChange();
    }
    public void SaveState( )
    {
        string s = "";
        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += weapon.weaponLevel.ToString();
        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
{
        SceneManager.sceneLoaded -= LoadState;
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }
        string[] data = PlayerPrefs.GetString("SaveSate").Split('|');
        //change playerSking
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        if(GetCurrentLevel() != 1)
        {
            player.SetLevel(GetCurrentLevel());
        }
       
        //change the weapon level
        weapon.SetWeaponLevel(int.Parse(data[3]));

       
    }
    
    public void OnSceneLoaded(Scene s, LoadSceneMode mode)
    {
        player.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }
}
