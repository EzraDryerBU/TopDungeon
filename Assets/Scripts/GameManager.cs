using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    private void Awake() {

        if(GameManager.instance != null) {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //Refrences
    public Player player;
    public FloatingTextManager floatingTextManager;

    //Stats
    public int pesos;
    public int experince;

    //Function for making floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration) {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    //Save States
    /*
     INT perferedSkin
     INT pesos
     INT experience
     INT weaponLevel
     */
    public void SaveState() {
        string s = "";

        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experince.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveSate", s);
        Debug.Log("Save State");
    }

    public void LoadState(Scene s, LoadSceneMode mode) {

        if (!PlayerPrefs.HasKey("SaveState")) return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change player skin, not in right now
        pesos = int.Parse(data[1]);
        experince = int.Parse(data[2]);
        //Change the weapon level, also not in rn

        Debug.Log("Load Save");
    }

}
