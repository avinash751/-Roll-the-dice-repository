using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance { get; private set;}
    public float CurrentTime;
    [Header(" Finding references info")]
    public List<EnemyAi> EnemyList = new List<EnemyAi>();


    public delegate void EnemyDiceEvent();

    public void Awake()
    {
        if(instance == null)
        {   
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        
       
    }

   



    public void AddEnemyToList(EnemyAi enemy)
    {
       EnemyList.Add(enemy);
    }

    public void RemoveEnemyFromList(EnemyAi enemy)
    {
        EnemyList.Remove(enemy);
    }
}
