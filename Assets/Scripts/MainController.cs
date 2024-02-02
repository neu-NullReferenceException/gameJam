using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    void OnApplicationQuit()
    {
        StaticTicker.StopTick();
    }
    // Start is called before the first frame update
    void Start()
    {
        StaticTicker.StartTick();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
