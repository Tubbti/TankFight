using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{
    private ArrayList tanks = new ArrayList();
    private int gameRoundCount = 2;
    public TankManager(int gameRoundCount)
    {
        this.gameRoundCount = gameRoundCount;
    }
    public void AddTank(Tank tank)
    {
        tanks.Add(tank);
    }
    public Transform[] GetTanksTransforms()
    {
        Transform[] targets = new Transform[tanks.Count];
       for(int i=0;i<tanks.Count;i++)
       {
           Tank tank = (Tank)tanks[i];
           targets[i] = tank.GetTankGameObject().transform;
       }
       return targets;
    }
    public Transform GetTank1Transform()
    {
        Transform target1;
        Tank tank = (Tank)tanks[0];
        target1 = tank.GetTankGameObject().transform;
        return target1;
    }
    public Transform GetTank2Transform()
    {
        Transform target2;
        Tank tank = (Tank)tanks[1];
        target2 = tank.GetTankGameObject().transform;
        return target2;
    }
    public bool IsOneTankLeft()
    {
        int numTanksLeft = 0;
        foreach(Tank tank in tanks)
        {
            if(tank.GetTankGameObject().activeSelf)
            {
                numTanksLeft++;
            }
        }
        return numTanksLeft <=1;
    }

    public Tank GetRoundWinner()
    {
        foreach(Tank tank in tanks)
        {
            if(tank.GetTankGameObject().activeSelf)
            {
                return tank;
            }
        }
        return null;
    }
    public Tank GetRoundLoser()
    {
        foreach(Tank tank in tanks)
        {
            if(!tank.GetTankGameObject().activeSelf)
            {
                return tank;
            }
        }
        return null;
    }
    public Tank GetGameWinner()
    {
        foreach(Tank tank in tanks)
        {
            if(tank.GetRoundWinnerCount() == gameRoundCount)
            {
                return tank;
            }
        }
        return null;
    }
    public void EnableTanks(bool enable)
    {
        foreach(Tank tank in tanks)
        {
            tank.Enable(enable);
        }
    }
    public void ResetTanks()
    {
        foreach(Tank tank in tanks)
        {
            tank.Reset();
        }
    }
}
