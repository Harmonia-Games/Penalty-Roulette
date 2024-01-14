using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalButton : MonoBehaviour
{
    [SerializeField] Animator classicButtonAnimator;
    [SerializeField] Animator betButtonAnimator;
    [SerializeField] TMP_Text MoneyText;

    public float multiply;
    float currentBet;

    public bool selectClassic, selectFirstEight, selectSecondEight, selectThirdEight,
                 selectOneToTwelve, selectTwelveToTwentyFour, selectBlue, selectYellow, selectEven, selectOdd;


    public void ResetButton()
    {
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
    
    private bool AnySelectionTrue() =>
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

    public float GetWinBetValue()
    {
        return currentBet * multiply;
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
