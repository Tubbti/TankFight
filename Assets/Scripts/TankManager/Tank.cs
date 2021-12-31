using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Tank
{
    public Color skinColor;
    public Transform spawnPoint;
    public GameObject tankGameObject;
    public int playerNumber;
    public int roundWinnerCount = 0;
    public void SetTankColor(Color color)
    {
        MeshRenderer[] renderers = 
        tankGameObject.GetComponentsInChildren<MeshRenderer>();
        foreach(MeshRenderer renderer in renderers)
        {
            renderer.material.color = color;
        }
    }
    private void SetTankPlayerNumber(int playerNumber)
    {
        TankMovement tm = tankGameObject.GetComponent<TankMovement>();
        tm.SetPlayerNumber(playerNumber);
        TankAttack ts = tankGameObject.GetComponent<TankAttack>();
        ts.SetPlayerNumber(playerNumber);
    }
    public void Setup(GameObject tankGameObject,int number,Color skinColor)
    {
        this.tankGameObject = tankGameObject;
        this.playerNumber = number;
        this.skinColor = skinColor;
        SetTankColor(this.skinColor);
        SetTankPlayerNumber(this.playerNumber);
    }
    public GameObject GetTankGameObject()
    {
        return tankGameObject;
    }
    public int GetRoundWinnerCount()
    {
        return roundWinnerCount;
    }
    public void IncreaseRoundWinnerCount()
    {
        roundWinnerCount++;
    } 
    public void Reset()
    {
        tankGameObject.SetActive(true);
        tankGameObject.transform.position = spawnPoint.position;
        tankGameObject.transform.rotation = spawnPoint.rotation;

        TankHealth th =this.tankGameObject.GetComponent<TankHealth>();
        th.ResetHealth();
    }
    public void Enable(bool enable)
    {
        TankAttack ts = this.tankGameObject.GetComponent<TankAttack>();
        ts.enabled = enable;
        TankMovement tm = this.tankGameObject.GetComponent<TankMovement>();
        tm.enabled = enable;
    }
}
