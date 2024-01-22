using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BetManager : MonoBehaviour
{
    public static BetManager Instance;

    [Header("Bet Money")]
    [SerializeField] private float currentBet;
    [SerializeField] private float betMoneyValue;

    public float calculateWinPayment;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        IncreaseBetValue();
    }

    public float UpdateCurrentBet(float bet)
    {
        return currentBet += bet;
    }

    public float GetCurrentBet()
    {
        return currentBet;
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
    }

    public void BetResult()
    {
        StartCoroutine(BetResultProcess());
    }

    private IEnumerator BetResultProcess()
    {
        if (calculateWinPayment > 0)
        {
            yield return new WaitForSeconds(1f);
            Vault.instance.SetCaseMoneyValue(calculateWinPayment);

            UIManager.instance.winPopUp.SetActive(true);

            yield return new WaitForSeconds(1.5f);

            UIManager.instance.winPopUp.SetActive(false);

            calculateWinPayment = 0;

            GameManager.instance.RestartGame();

            currentBet = 0;
        }
        else
        {
            yield return new WaitForSeconds(2f);
            calculateWinPayment = 0;
            GameManager.instance.RestartGame();
            currentBet = 0;
        }
    }
}
