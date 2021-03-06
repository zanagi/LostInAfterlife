﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event/Combat/Combat Event")]
public class CombatEvent : GameEvent
{
    public EnemyGroup EnemyGroup { get; private set; }
    public GameObject EnemyObject { get; private set; }

    public void StartCombat(EnemyGroup enemyGroup, GameObject enemyObject)
    {
        EnemyGroup = enemyGroup;
        EnemyObject = enemyObject;
        Raise();
    }
}
