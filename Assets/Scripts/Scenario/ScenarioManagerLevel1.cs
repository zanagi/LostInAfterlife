﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManagerLevel1 : ScenarioManager
{
    public EnemyGroup enemyGroupA, enemyGroupB;
    public GameObject enemyA, enemyB;
    public LevelPortal portal;
    public Dialogue portalDialogue;
    private int count;

    public override void PlayScenario(Scenario scenario)
    {
        switch(scenario)
        {
            case Scenario.Level1_FightA:
                combatEvent.StartCombat(enemyGroupA, enemyA);
                CheckCount();
                break;
            case Scenario.Level1_FightB:
                combatEvent.StartCombat(enemyGroupB, enemyB);
                CheckCount();
                break;
            case Scenario.Level1_FightB_Pay:
                GameManager.Instance.player.PayHealth(10);
                combatEvent.StartCombat(enemyGroupB, enemyB);
                CheckCount();
                break;
            case Scenario.Level1_PortalEnd:
                portal.blockDialogue = null;
                break;
        }
    }

    private void CheckCount()
    {
        count++;

        if(count >= 2)
        {
            portal.blockDialogue = portalDialogue;
        }
    }
}
