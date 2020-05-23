using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button myButton;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        myButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
        PlayerStats.SetActive(true);
        Debug.Log(PlayerStats.GetActive());
        SceneManager.LoadScene(1);
    }
}
