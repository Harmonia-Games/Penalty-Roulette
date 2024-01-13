using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BetButton : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] TMP_Text DemText;
    public float multiply;
    float currentBet;
    bool select;

    public void Select()
    {
        if (!select)
        {
            animator.SetTrigger("Select");
            currentBet = BetManager.instance.GetCurrentDemValue();
            UpdateDemText();
        }
        else
        {
            animator.SetTrigger("Deselect");
        }

        select = !select;
    }
    private void UpdateDemText()
    {
        DemText.text = "DEM " + BetManager.instance.GetCurrentDemValue().ToString("#,##0.00", System.Globalization.CultureInfo.InvariantCulture);
    }
}
