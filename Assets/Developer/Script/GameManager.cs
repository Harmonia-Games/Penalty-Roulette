using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isTestBuild;

    public float chanceForSave;
    public float chanceForMiss;
    public float chanceForGoal;

    public float gameCoolDown;

    private bool isGameStart;

    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        GetComponent<GameScenarios>().Play();
        isGameStart = true;
    }
    public void RestartGame()
    {
        isGameStart = false;
        GetComponent<GameScenarios>().ResetScenerios();
        UIManager.instance.EnableInteractBetButtons();
        UIManager.instance.ResetButtons();
    }
}
