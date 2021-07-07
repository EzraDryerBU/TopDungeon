using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    private void Awake() {
        instance = this;
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //Refrences
    public Player player;

    //Stats
    public int pesos;
    public int experince;

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
    }

    public void LoadState() {
        if (!PlayerPrefs.HasKey("SaveState")) return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change player skin, not in right now
        pesos = int.Parse(data[1]);
        experince = int.Parse(data[2]);
        //Change the weapon level, also not in rn

        Debug.Log("Load Save");
    }

}
