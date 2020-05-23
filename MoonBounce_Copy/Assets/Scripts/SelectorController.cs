using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectorController : MonoBehaviour
{
    private float x;
    private float y;
    public float upperBound;
    public float lowerBound;
    public float rightBound;
    public float leftBound;

    public bool blockPlaced;

    // Start is called before the first frame update
    void Start()
    {
        x = -7.5f;
        y = 2.5f;
    }

    public float GetX(){
      return x;
    }

    public float GetY(){
      return y;
    }

    public Vector3 GetPos(){
      return transform.position;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
        //blockPlaced = (LayerMask.LayerToName(collision.gameObject.layer) == "Blocks");
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && y < upperBound){
            y++;
        }
        else if (Input.GetKeyDown(KeyCode.S) && y > lowerBound){
            y--;
        }
        else if (Input.GetKeyDown(KeyCode.D) && x < rightBound){
            x++;
        }
        else if (Input.GetKeyDown(KeyCode.A) && x > leftBound){
            x--;
        }

        transform.position = new Vector3(x, y, 0.0f);

    }
}
