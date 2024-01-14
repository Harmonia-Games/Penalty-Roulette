using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BetButton : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] TMP_Text moneyText;
    public float multiply;
    float currentBet;
    public bool select;

    public void Select()
    {
        if (!select)
        {
            animator.SetTrigger("Select");
            currentBet = BetManager.instance.GetBetMoneyValue();
            UpdateMoneyText();
            BetManager.instance.UpdateCurrentBet(currentBet);
        }
        else
        {
            animator.SetTrigger("Deselect");
            BetManager.instance.UpdateCurrentBet(-currentBet);
        }

        select = !select;
    }
    private void UpdateMoneyText()
    {
        moneyText.text = "USD " + BetManager.instance.GetBetMoneyValue().ToString("#,##0.00", System.Globalization.CultureInfo.InvariantCulture);
    }
    public float GetWinBetValue()
    {
        return currentBet * multiply;
    }
}
