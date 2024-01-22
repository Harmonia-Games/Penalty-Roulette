using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BetManager : MonoBehaviour
{
    public static BetManager instance;

    [Header("Bet Money")]
    [SerializeField] float currentBet;
    [SerializeField] float betMoneyValue;
    [SerializeField] TMP_Text betMoneyValueText;

    [Header("Case Balance")]
    [SerializeField] float caseMoneyValue;
    [SerializeField] TMP_Text caseMoneyValueText;

    [Header("Win UI")]
    [SerializeField] TMP_Text winText;
    [SerializeField] TMP_Text winPopUpText;
    [SerializeField] GameObject winPopUp;

    public float calculateWinPayment;


    private void Awake()
    {
        instance = this;
        caseMoneyValue = 5000;
    }

    private void Start()
    {
        IncreaseBetValue();
        UpdateMoneyTexts();
    }
    public float UpdateCurrentBet(float bet)
    {
        return currentBet+=bet;
    }
    public float CurrentBet()
    {
        return currentBet;
    }
    public float GetBetMoneyValue()
    {
        return betMoneyValue;
    }
    public float SetCaseMoneyValue(float value)
    {
        return caseMoneyValue += value;
    }

    public float GetCurrentCaseValue()
    {
        return caseMoneyValue;
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

        UpdateMoneyTexts();
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

        UpdateMoneyTexts();
    }

    public void UpdateMoneyTexts()
    {
        betMoneyValueText.text = "USD " + GetBetMoneyValue().ToString("#,##0.00", System.Globalization.CultureInfo.InvariantCulture);
        caseMoneyValueText.text = "USD " + GetCurrentCaseValue().ToString("#,##0.00", System.Globalization.CultureInfo.InvariantCulture);
        winText.text = "USD " + calculateWinPayment.ToString("#,##0.00", System.Globalization.CultureInfo.InvariantCulture);
        winPopUpText.text = "USD " + calculateWinPayment.ToString("#,##0.00", System.Globalization.CultureInfo.InvariantCulture);
    }

    public void WinLose()
    {
        StartCoroutine(WinLoseProcess());
    }
    IEnumerator WinLoseProcess()
    {
        if (calculateWinPayment > 0)
        {
            yield return new WaitForSeconds(1f);
            caseMoneyValue += calculateWinPayment;
            UpdateMoneyTexts();
            winPopUp.SetActive(true);

            yield return new WaitForSeconds(1.5f);

            winPopUp.SetActive(false);
            calculateWinPayment = 0;
            GameManager.instance.RestartAction();
            currentBet = 0;

        }
        else
        {
            yield return new WaitForSeconds(2f);
            calculateWinPayment = 0;
            GameManager.instance.RestartAction();
            currentBet = 0;
        }
    }

   

}
