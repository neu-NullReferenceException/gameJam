using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour
{
    public int defaultConsumption;
    public int currentTier = 0;
    public int people;
    public BuidingTier[] buidingTiers;
    public int peopleConsumptionMultiplyer;
    public bool isConnectedToGrid = false;

    private float outageTimeStart;
    private float outageTimeLength;
    private bool outageStarted = false;

    //kap elég áramot?
    public bool IsFulfilled(int inputPower)
    {
        if(inputPower >= CalculateConsumption())
        {
            if (outageStarted)
            {
                outageTimeLength = Time.time - outageTimeStart;
                outageStarted = false;
            }
            return true;
        }

        if (!outageStarted)
        {
            outageStarted = true;
            outageTimeStart = Time.time;
        }
        return false;
    }

    public int CalculateConsumption()
    {
        return defaultConsumption + (people * peopleConsumptionMultiplyer);
    }
}

[System.Serializable]
public class BuidingTier
{
    public int minPeople;
    public int maxPeople;
    public GameObject tierVisual;
}