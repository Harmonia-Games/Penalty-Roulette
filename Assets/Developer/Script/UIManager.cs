using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("All Game Buttons")]
    public Button[] gameButtons;
    public GoalButton[] goalBetButtons;
    public BetButton[] betButtons;

    [Header("Panel")]
    public GameObject[] hideBetUI;
    public GameObject insufficientBalanceUI;
    public GameObject winPopUp;

    [Header("Texts")]
    [SerializeField] TMP_Text caseMoneyValueText;
    [SerializeField] TMP_Text betMoneyValueText;
    [SerializeField] TMP_Text winPopUpText;
    [SerializeField] TMP_Text winText;

    [Header("BetButtons")]
    public BetButton firstEight;
    public BetButton secondEight;
    public BetButton thirdEight;

    public BetButton firstTwelve;
    public BetButton secondTwelve;

    public BetButton blue;
    public BetButton yellow;

    public BetButton miss;
    public BetButton even;
    public BetButton odd;
    public BetButton save;

    


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateMoneyTexts();
    }
    public void EnableInteractBetButtons()
    {
        foreach (var item in goalBetButtons)
        {
            item.EnableEventTrigger();
        }
        foreach (var item in betButtons)
        {
            item.EnableEventTrigger();
        }
    }
    public void DisableInteractBetButtons()
    {
        foreach (var item in goalBetButtons)
        {
            item.DisableEventTrigger();
        }
        foreach (var item in betButtons)
        {
            item.DisableEventTrigger();
        }
    }
    public void OpenInsufficientBalance()
    {
        insufficientBalanceUI.SetActive(true);
    }
    public void UpdateMoneyTexts()
    {
        betMoneyValueText.text = "USD " + BetManager.instance.GetBetMoneyValue().ToString("#,##0.00", System.Globalization.CultureInfo.InvariantCulture);
        caseMoneyValueText.text = "USD " + Vault.instance.GetCurrentCaseValue().ToString("#,##0.00", System.Globalization.CultureInfo.InvariantCulture);
        winText.text = "USD " + BetManager.instance.calculateWinPayment.ToString("#,##0.00", System.Globalization.CultureInfo.InvariantCulture);
        winPopUpText.text = "USD " + BetManager.instance.calculateWinPayment.ToString("#,##0.00", System.Globalization.CultureInfo.InvariantCulture);
    }


}
