using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalButton : MonoBehaviour
{
    [SerializeField] Animator DemAnimator;
    [SerializeField] Animator Betanimator;
    [SerializeField] TMP_Text DemText;

    public float multiply;
    float currentBet;

    private bool selectClassic, selectFirstEight, selectSecondEight, selectThirdEight,
                 selectOneToTwelve, selectTwelveToTwentyFour, selectBlue, selectYellow, selectEven, selectOdd;

    private void UpdateDemText()
    {
        DemText.text = "DEM " +BetManager.instance.GetCurrentDemValue().ToString("#,##0.00", System.Globalization.CultureInfo.InvariantCulture);
    }

    private void ToggleSelection(ref bool selection, Animator animator)
    {
        selection = !selection;

        if (!AnySelectionTrue())
        {
            animator.SetTrigger("Deselect");
        }
        else if (selection)
        {
            animator.SetTrigger("Select");
        }
    }

    private bool AnySelectionTrue() =>
        selectClassic || selectFirstEight || selectSecondEight || selectThirdEight ||
        selectOneToTwelve || selectTwelveToTwentyFour || selectBlue || selectYellow || selectEven || selectOdd;

    public void SelectClassic()
    {
        if (!selectClassic)
        {
            DemAnimator.SetTrigger("Select");
            currentBet = BetManager.instance.GetCurrentDemValue();
            UpdateDemText();
        }
        else
        {
            DemAnimator.SetTrigger("Deselect");
        }

        selectClassic = !selectClassic;
    }
    public void SelectBetFirstEight() { ToggleSelection(ref selectFirstEight, Betanimator);  } 
    public void SelectBetSecondEight() => ToggleSelection(ref selectSecondEight, Betanimator);
    public void SelectBetThirdEight() => ToggleSelection(ref selectThirdEight, Betanimator);
    public void SelectBetOneToTwelve() => ToggleSelection(ref selectOneToTwelve, Betanimator);
    public void SelectBetTwelveToTwentyFour() => ToggleSelection(ref selectTwelveToTwentyFour, Betanimator);
    public void SelectBetBlue() => ToggleSelection(ref selectBlue, Betanimator);
    public void SelectBetYellow() => ToggleSelection(ref selectYellow, Betanimator);
    public void SelectBetEven() => ToggleSelection(ref selectEven, Betanimator);
    public void SelectBetOdd() => ToggleSelection(ref selectOdd, Betanimator);
}
