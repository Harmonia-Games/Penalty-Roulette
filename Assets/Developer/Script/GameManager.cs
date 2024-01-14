using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("General Stuff")]
    [SerializeField] GameObject insufficientBalanceUI;
    [SerializeField] GameObject[] hideBetUI;
    [SerializeField] Button[] gameButtons;
    bool isGameStart;

    [Header("Ball")]
    [SerializeField] Transform[] ballTarget;
    [SerializeField] Transform[] ballCurve;
    [SerializeField] GameObject[] missScenarios;
    [SerializeField] GameObject[] saveScenerios;
    [SerializeField] int shootNumber;
    [SerializeField] Ball ball;

    [Header("Goal")]
    [SerializeField] GoalButton[] goalButtons;
    [SerializeField] BetButton[] betButtons;

    [Header("BetButtons")]
    [SerializeField] BetButton firstEight;
    [SerializeField] BetButton secondEight;
    [SerializeField] BetButton thirdEight;

    [SerializeField] BetButton firstTwelve;
    [SerializeField] BetButton secondTwelve;

    [SerializeField] BetButton blue;
    [SerializeField] BetButton yellow;

    [SerializeField] BetButton miss;
    [SerializeField] BetButton even;
    [SerializeField] BetButton odd;
    [SerializeField] BetButton save;

    private void Awake()
    {
        instance = this;
    }

    public void Play()
    {
        if (BetManager.instance.CurrentBet() <= BetManager.instance.GetCurrentCaseValue())
        {
            StartAction();
            BetManager.instance.SetCaseMoneyValue(-BetManager.instance.CurrentBet());
            BetManager.instance.UpdateMoneyTexts();
        }
        else
        {
            Debug.Log("You have insufficient balance");
            insufficientBalanceUI.SetActive(true);
        }
    }

    private void StartAction()
    {
        isGameStart = true;
        InteractableGameButtons();
        Randomize();
    }
    public void RestartAction()
    {
        isGameStart = false;
        ResetAllButtons();
        InteractableGameButtons();
    }
    public void ResetAllButtons()
    {
        foreach (var item in goalButtons)
        {
           item.ResetButton();
        }
        foreach (var item in betButtons)
        {
            if (item.select)
            {
                item.Select();
            }
        }
        foreach (var item in missScenarios)
        {
            item.SetActive(false);
        }
        foreach (var item in saveScenerios)
        {
            item.SetActive(false);
        }
    }

    private void InteractableGameButtons()
    {
        foreach (var item in gameButtons)
        {
            item.interactable = !isGameStart;
        }
    }
   
    private void Randomize()
    {
        float randomValue = Random.value;

        if (randomValue <= 0.5f) Goal();
        else if (randomValue <= 0.7f) Miss();
        else Save();
    }

    private void RandomizeShoot()
    {
        shootNumber = Random.Range(1, 25);
    }

    private void Save()
    {
        ActivateRandomSaveScenario();

        if (save.select)
        {
            BetManager.instance.calculateWinPayment += save.GetWinBetValue();
        }

        BetManager.instance.WinLose();
    }

    private void Miss()
    {
        ActivateRandomMissScenario();

        if (miss.select)
        {
            BetManager.instance.calculateWinPayment += miss.GetWinBetValue();
        }

        BetManager.instance.WinLose();
    }
    private void ActivateRandomMissScenario()
    {
        int randomMissIndex = Random.Range(0, missScenarios.Length);
        missScenarios[randomMissIndex].SetActive(true);
    }
    private void ActivateRandomSaveScenario()
    {
        int randomMissIndex = Random.Range(0, saveScenerios.Length);
        saveScenerios[randomMissIndex].SetActive(true);
    }
    private void Goal()
    {
        RandomizeShoot();
        ball.gameObject.SetActive(true);
        ball.curvePosition = ballCurve[shootNumber-1];
        ball.targetPosition = ballTarget[shootNumber-1];
        ball.MoveWithCurve();


        GoalBetControl();
        BetManager.instance.WinLose();
    }

    private void GoalBetControl()
    {
        SelectClassicBetControl();
        SelectEightsControl();
        SelectTwelvesControl();
        SelectOddEvenControl();
        SelectColorControl();
    }

    private void SelectTwelvesControl()
    {
        if (shootNumber <= 12 && firstTwelve.select)
        {
            BetManager.instance.calculateWinPayment += firstTwelve.GetWinBetValue();
        }
    }

    private void SelectEightsControl()
    {
        if (shootNumber <= 8 && firstEight.select)
        {
            BetManager.instance.calculateWinPayment += firstEight.GetWinBetValue();
        }
        else if (shootNumber <= 16 && secondEight.select)
        {
            BetManager.instance.calculateWinPayment += secondEight.GetWinBetValue();
        }
        else if (thirdEight.select)
        {
            BetManager.instance.calculateWinPayment += thirdEight.GetWinBetValue();
        }
    }

    private void SelectOddEvenControl()
    {
        if (shootNumber % 2 == 0 && even.select)
        {
            BetManager.instance.calculateWinPayment += even.GetWinBetValue();
        }
        else if (shootNumber % 2 != 0 && odd.select)
        {
            BetManager.instance.calculateWinPayment += odd.GetWinBetValue();
        }
    }

    private void SelectColorControl()
    {
        int[] blueNumbers = { 1, 3, 5, 8, 10, 12, 13, 15, 17, 20, 22, 24 };

        if (System.Array.Exists(blueNumbers, element => element == shootNumber))
        {
            BetManager.instance.calculateWinPayment += blue.select ? blue.GetWinBetValue() : 0;
        }
        else
        {
            BetManager.instance.calculateWinPayment += yellow.select ? yellow.GetWinBetValue() : 0;
        }
    }

    private void SelectClassicBetControl()
    {
        print(shootNumber);
        if (goalButtons[shootNumber-1].selectClassic)
        {
            BetManager.instance.calculateWinPayment += goalButtons[shootNumber].GetWinBetValue();
        }
    }
}
