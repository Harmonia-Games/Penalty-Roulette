using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BetManager : MonoBehaviour
{
    public static BetManager instance;

    [Header("Bet Money")]
    [SerializeField] float currentPot;
    [SerializeField] float betMoneyValue;

    public float calculateWinPayment;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        IncreaseBetValue();
    }

    public float UpdateCurrentPot(float bet)
    {
        return currentPot+=bet;
    }

    public float CurrentPot()
    {
        return currentPot;
    }

    public float GetBetMoneyValue()
    {
        return betMoneyValue;
    }

    public void IncreaseBetValue()
    {
        float[] increments = { 1, 2, 3, 5, 10, 20, 30, 50, 75, 100, 200, 300, 400, 500, 1000, 3000, 5000, 10000, 20000, 30000 };

        for (int i = 0; i < increments.Length; i++)
        {
            if (betMoneyValue < increments[i])
            {
                betMoneyValue = increments[i];
                break;
            }
        }
        UIManager.instance.UpdateMoneyTexts();
    }

    public void DecreaseBetValue()
    {
        float[] decrements = { 30000, 20000, 10000, 5000, 3000, 1000, 500, 400, 300, 200, 100, 75, 50, 30, 20, 10, 5, 3, 2, 1 };

        for (int i = 0; i < decrements.Length; i++)
        {
            if (betMoneyValue > decrements[i])
            {
                betMoneyValue = decrements[i];
                break;
            }
        }
        UIManager.instance.UpdateMoneyTexts();
    }

    public void BetResult()
    {
        StartCoroutine(BetResultProcess());
    }

    IEnumerator BetResultProcess()
    {
        if (calculateWinPayment > 0)
        {
            yield return new WaitForSeconds(1f);

            Vault.instance.SetCaseMoneyValue(calculateWinPayment);

            UIManager.instance.winPopUp.SetActive(true);
            UIManager.instance.UpdateMoneyTexts();

            yield return new WaitForSeconds(GameManager.instance.gameCoolDown);

            UIManager.instance.winPopUp.SetActive(false);

            calculateWinPayment = 0;

            GameManager.instance.RestartGame();

            currentPot = 0;

        }
        else
        {
            yield return new WaitForSeconds(GameManager.instance.gameCoolDown);
            calculateWinPayment = 0;
            GameManager.instance.RestartGame();
            currentPot = 0;
        }
    }

}
