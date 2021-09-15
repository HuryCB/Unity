using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject textPrefab;
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
    
    void Text(string text, Vector3 position)
    {
        if (textPrefab)
        {
            GameObject prefab = Instantiate(textPrefab, position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
        }
    }
    public void SaveState() 
    {

    }

    public void LoadState()
    {
         
    }

    private void Update()
    {
        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
