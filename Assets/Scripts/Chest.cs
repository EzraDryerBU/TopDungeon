using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable {

    public Sprite emptyChest;
    public int pesosAmount = 5;

    protected override void OnCollect() {

        if (!collected) {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.ShowText("+" + pesosAmount + " Pesos Granted!", 30, Color.yellow, transform.position, Vector3.up * 30, 1.5f);
        }


    }
}
