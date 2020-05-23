using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlockManager : MonoBehaviour
{

    public SelectorController selector;
    public AutoAstronaut astronaut;
    public GameObject blockPrefab;
    private int AstronautXCor;
    public int maxStack;

    public int[] positives = {0, 0, 0, 0, 0, 0, 0, 0};
    public int[] negatives = {0, 0, 0, 0, 0, 0, 0, 0};

    // Start is called before the first frame update
    void Start()
    {
        CountBlocks();
        Debug.Log(positives);
        Debug.Log(negatives);
    }

    private void CountBlocks()
    {
        Array.Clear(positives, 0, positives.Length);
        Array.Clear(negatives, 0, negatives.Length);
        foreach (Transform child in transform)
        {
            float blockxPos = child.transform.position.x;
            LogBlock(blockxPos);
        }
    }

    public void LogBlock(float blockxpos)
    {
        int spot = (int)blockxpos;

        if (blockxpos > 0)
        {
            positives[spot] += 1;
        }
        else
        {
            spot = spot * -1;
            negatives[spot] += 1;
        }
    }

    public int GetBlockCount(float xPos)
    {
        int spot = (int)xPos;

        if (xPos > 0)
        {
            return positives[spot];
        }
        else
        {
            spot = spot * -1;
            return negatives[spot];
        }
    }

    private void AddBlock(){
        if (GetBlockCount(selector.GetX()) < 9){
            var newBlock = Instantiate(blockPrefab, selector.GetPos(), Quaternion.identity);
            newBlock.transform.parent = gameObject.transform;
        }
        //Debug.Log(count);
    }

    private void RemoveBlock(){

    }

    private bool SpotFull(){
        return false;
    }

    private bool StackFull(float xPos)
    {
        if ( Math.Abs(xPos - astronaut.GetX()) < 1 && (astronaut.GetY() - selector.GetY()) < 0.5){
            return true;
        }
        return (GetBlockCount(xPos) > maxStack);

    }

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space)){
          if (!StackFull(selector.GetX())){
              AddBlock();
          }
          /*if (SpotFull())
          {
              RemoveBlock();
          }
          else
          {
              AddBlock();
          }*/
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CountBlocks();
    }
}
