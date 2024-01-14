using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GoalButton : MonoBehaviour
{
    [SerializeField] Animator classicButtonAnimator;
    [SerializeField] Animator betButtonAnimator;
    [SerializeField] GameObject winAnimator;
    [SerializeField] GameObject failAnimator;
    [SerializeField] TMP_Text MoneyText;
    [SerializeField] CanvasGroup fadeCanvas;
    [SerializeField] Color defaultColor;
    [SerializeField] Color mouseEnterColor;
    [SerializeField] Image SelectableSprite;

    public float multiply;
    private float currentBet;
    private EventTrigger eventTrigger;



    public bool selectClassic, selectFirstEight, selectSecondEight, selectThirdEight,
                 selectOneToTwelve, selectTwelveToTwentyFour, selectBlue, selectYellow, selectEven, selectOdd;

    private void Start()
    {
        eventTrigger = GetComponent<EventTrigger>();
    }
    public void ColorChangeEnterMouse()
    {
        SelectableSprite.color = mouseEnterColor;
    }
    public void ColorChangeExitMouse()
    {
        SelectableSprite.color = defaultColor;
    }
    public void DisableEventTrigger()
    {
        eventTrigger.enabled = false;
        FadeInCanvas();
    }

    public void EnableEventTrigger()
    {
        eventTrigger.enabled = true;
        FadeOutCanvas();
    }
    public void ResetButton()
    {
        winAnimator.SetActive(false);
        failAnimator.SetActive(false);
        EnableEventTrigger();

        if (selectClassic)
        {
            classicButtonAnimator.SetTrigger("Deselect");
            BetManager.instance.UpdateCurrentBet(-currentBet);
            selectClassic = false;
        }

        if (AnySelectionTrue())
        {
            if (selectFirstEight) SelectBetFirstEight();
            if (selectSecondEight) SelectBetSecondEight();
            if (selectThirdEight) SelectBetThirdEight();
            if (selectOneToTwelve) SelectBetOneToTwelve();
            if (selectTwelveToTwentyFour) SelectBetTwelveToTwentyFour();
            if (selectBlue) SelectBetBlue();
            if (selectYellow) SelectBetYellow();
            if (selectEven) SelectBetEven();
            if (selectOdd) SelectBetOdd();
        }
    }
    private void UpdateMoneyText()
    {
        MoneyText.text = "USD " +BetManager.instance.GetBetMoneyValue().ToString("#,##0.00", System.Globalization.CultureInfo.InvariantCulture);
    }

    private void ToggleSelection(ref bool selection, Animator animator)
    {
        selection = !selection;

        if (!AnySelectionTrue())
        {
            animator.SetBool("Deselect",true);
            animator.SetBool("Select", false);
        }
        else if (AnySelectionTrue())
        {
            animator.SetBool("Deselect", false);
            animator.SetBool("Select", true);
            BetManager.instance.UpdateCurrentBet(currentBet);
        }
    }
    
    public bool AnySelectionTrue() =>
         selectFirstEight || selectSecondEight || selectThirdEight ||
        selectOneToTwelve || selectTwelveToTwentyFour || selectBlue || selectYellow || selectEven || selectOdd;

    public void SelectClassic()
    {
        if (!selectClassic)
        {
            classicButtonAnimator.SetTrigger("Select");
            currentBet = BetManager.instance.GetBetMoneyValue();
            BetManager.instance.UpdateCurrentBet(currentBet);
            UpdateMoneyText();
        }
        else
        {
            classicButtonAnimator.SetTrigger("Deselect");
            BetManager.instance.UpdateCurrentBet(-currentBet);
        }

        selectClassic = !selectClassic;
    }

    public void WinAnim()
    {
        winAnimator.SetActive(true);
        FadeOutCanvas();
    }
    public void FailAnim()
    {
        failAnimator.SetActive(true);
        FadeOutCanvas();
    }
    public float GetWinBetValue()
    {
        return currentBet * multiply;
    }
    public void FadeInCanvas()
    {
        fadeCanvas.alpha = 0.5f;
    }
    public void FadeOutCanvas()
    {
        fadeCanvas.alpha = 1f;
    }
    public void SelectBetFirstEight() { ToggleSelection(ref selectFirstEight, betButtonAnimator);  } 
    public void SelectBetSecondEight() => ToggleSelection(ref selectSecondEight, betButtonAnimator);
    public void SelectBetThirdEight() => ToggleSelection(ref selectThirdEight, betButtonAnimator);
    public void SelectBetOneToTwelve() => ToggleSelection(ref selectOneToTwelve, betButtonAnimator);
    public void SelectBetTwelveToTwentyFour() => ToggleSelection(ref selectTwelveToTwentyFour, betButtonAnimator);
    public void SelectBetBlue() => ToggleSelection(ref selectBlue, betButtonAnimator);
    public void SelectBetYellow() => ToggleSelection(ref selectYellow, betButtonAnimator);
    public void SelectBetEven() => ToggleSelection(ref selectEven, betButtonAnimator);
    public void SelectBetOdd() => ToggleSelection(ref selectOdd, betButtonAnimator);
}
