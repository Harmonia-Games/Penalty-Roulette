using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class BetButton : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] TMP_Text moneyText;
    [SerializeField] CanvasGroup fadeCanvas;
    public float multiply;
    public bool select;
    private EventTrigger eventTrigger;
    private float currentBet;

    private void Start()
    {
        eventTrigger = GetComponent<EventTrigger>();
    }
    private void Update()
    {
        print(eventTrigger.enabled);
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

    public void Select()
    {
        if (!select)
        {
            animator.SetTrigger("Select");
            currentBet = BetManager.instance.GetBetMoneyValue();
            UpdateMoneyText();
            BetManager.instance.UpdateCurrentPot(currentBet);
        }
        else
        {
            animator.SetTrigger("Deselect");
            BetManager.instance.UpdateCurrentPot(-currentBet);
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
    public void FadeInCanvas()
    {
        fadeCanvas.alpha = 0.5f;
    }
    public void FadeOutCanvas()
    {
        fadeCanvas.alpha = 1f;
    }
}
