using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTextManager : MonoBehaviour
{
    [SerializeField] private GameObject nextLevelText;
    [SerializeField] private GameObject restartText;
    // Start is called before the first frame update
    void Start()
    {
        restartText.SetActive(PlayerStats.AllLevelsCompleted());
        nextLevelText.SetActive(!PlayerStats.AllLevelsCompleted());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
