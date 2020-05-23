using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplayManager : MonoBehaviour
{
    private GameObject [][] allObjects;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.SetLevelCompleted(0);
        GameObject [][] mine = {GameObject.FindGameObjectsWithTag("Gem"), GameObject.FindGameObjectsWithTag("Rock"),
                                  GameObject.FindGameObjectsWithTag("Mushroom"), GameObject.FindGameObjectsWithTag("Box")};
        allObjects = mine;
        HideAll();
        // reveal completed level items only
        for (int x = 0; x < PlayerStats.GetLevelCount(); x++)
        {
            if (PlayerStats.CheckIsCompleted(x))
            {
              foreach (GameObject g in allObjects[x])
              {
                  g.SetActive(true);
              }
            }
        }
    }

    private void HideAll()
    {
        for (int a = 0; a < transform.childCount; a++)
        {
            transform.GetChild(a).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
