using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using MyRandomGenerator = System.Random;


public class ItemManager : MonoBehaviour
{
    public int levelNum;
    public GameObject[] itemTypes;
    private int liveItems;
    public GameObject myItem;
    public UnityEvent EndGameEvent;


    // Start is called before the first frame update
    void Start()
    {
        levelNum = PlayerStats.GetNextLevel();
        MyRandomGenerator random = new MyRandomGenerator();
        myItem = itemTypes[levelNum];
        for (int y = 0; y < 5; y++)
        {
            float myY = (float)y - 1.5f;
            float randomX = ((float)random.Next(-8, 8)) + 0.5f;
            Vector3 myPos = new Vector3(randomX, myY, 0f);
            PlaceItem(myPos);
        }

    }

    private int GetItemCount()
    {
        int itemCount = 0;
        foreach (Transform child in transform)
        {
            itemCount++;
        }
        return itemCount;
    }

    private void PlaceItem(Vector3 pos){
        var newItem = Instantiate(myItem, pos, Quaternion.identity);
        newItem.transform.parent = gameObject.transform;
    }

    private bool SpotFull(Vector3 pos){
        foreach (Transform child in transform)
        {
            if (child.transform.position == pos){
                return true;
            }
        }
        return false;
    }

    void FixedUpdate()
    {
        if (GetItemCount() == 0){
            EndGameEvent.Invoke();
            Debug.Log("END GAME");
        }
    }
}
