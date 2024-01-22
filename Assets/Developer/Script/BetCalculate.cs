using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetCalculate : MonoBehaviour
{
    public static BetCalculate instance;

    private int shootNumber;


    private void Awake()
    {
        instance = this;
    }

    public void MisBetCalculate()
    {
        if (UIManager.instance.miss.select)
        {
            BetManager.instance.calculateWinPayment += UIManager.instance.miss.GetWinBetValue();
        }

        BetManager.instance.BetResult();
    }
    public void SaveBetCalculate()
    {
        if (UIManager.instance.save.select)
        {
            BetManager.instance.calculateWinPayment += UIManager.instance.save.GetWinBetValue();
        }

        BetManager.instance.BetResult();
    }
    public void GoalBetCalculate(int _shootNumber)
    {
        shootNumber = _shootNumber;

        SelectClassicBetControl();
        SelectEightsControl();
        SelectTwelvesControl();
        SelectOddEvenControl();
        SelectColorControl();

        BetManager.instance.BetResult();
    }

    private void SelectTwelvesControl()
    {
        if (shootNumber <= 12 && UIManager.instance.firstTwelve.select)
        {
            BetManager.instance.calculateWinPayment += UIManager.instance.firstTwelve.GetWinBetValue();
        }
    }

    private void SelectEightsControl()
    {
        if (shootNumber <= 8 && UIManager.instance.firstEight.select)
        {
            BetManager.instance.calculateWinPayment += UIManager.instance.firstEight.GetWinBetValue();
        }
        else if (shootNumber > 8 && shootNumber <= 16 && UIManager.instance.secondEight.select)
        {
            BetManager.instance.calculateWinPayment += UIManager.instance.secondEight.GetWinBetValue();
        }
        else if (shootNumber > 8 && shootNumber > 16 && UIManager.instance.thirdEight.select)
        {
            BetManager.instance.calculateWinPayment += UIManager.instance.thirdEight.GetWinBetValue();
        }
    }

    private void SelectOddEvenControl()
    {
        if (shootNumber % 2 == 0 && UIManager.instance.even.select)
        {
            BetManager.instance.calculateWinPayment += UIManager.instance.even.GetWinBetValue();
        }
        else if (shootNumber % 2 != 0 && UIManager.instance.odd.select)
        {
            BetManager.instance.calculateWinPayment += UIManager.instance.odd.GetWinBetValue();
        }
    }

    private void SelectColorControl()
    {
        int[] blueNumbers = { 1, 3, 5, 8, 10, 12, 13, 15, 17, 20, 22, 24 };

        if (System.Array.Exists(blueNumbers, element => element == shootNumber))
        {
            BetManager.instance.calculateWinPayment += UIManager.instance.blue.select ? UIManager.instance.blue.GetWinBetValue() : 0;
        }
        else
        {
            BetManager.instance.calculateWinPayment += UIManager.instance.yellow.select ? UIManager.instance.yellow.GetWinBetValue() : 0;
        }
    }

    private void SelectClassicBetControl()
    {
        print(shootNumber);
        if (UIManager.instance.goalBetButtons[shootNumber - 1].selectClassic)
        {
            BetManager.instance.calculateWinPayment += UIManager.instance.goalBetButtons[shootNumber].GetWinBetValue();
            UIManager.instance.goalBetButtons[shootNumber - 1].WinAnim();
        }
        else if (!UIManager.instance.goalBetButtons[shootNumber - 1].AnySelectionTrue())
        {
            UIManager.instance.goalBetButtons[shootNumber - 1].FailAnim();
        }
        else if (UIManager.instance.goalBetButtons[shootNumber - 1].AnySelectionTrue())
        {
            UIManager.instance.goalBetButtons[shootNumber - 1].WinAnim();
        }
    }
}
