using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BetButtonManager : MonoBehaviour
{
    [SerializeField] GameObject[] FirstEight, SecondEight, ThirthEight, oneToTwelve, TwelveToTwentyFour, Blue, Yellow, Even, Odd;

    private const string FirstEightString = "FirstEight", SecondEightString = "SecondEight", ThirthEightString = "ThirthEight",
                         OneToTwelveString = "OneToTwelve", TwelveToTwentyFourString = "TwelveToTwentyFour", BlueString = "Blue",
                         YellowString = "Yellow", EvenString = "Even", OddString = "Odd";

    private void TriggerEnterAction(GameObject[] objectsToTrigger, ExecuteEvents.EventFunction<IPointerEnterHandler> action)
    {
        foreach (var item in objectsToTrigger)
        {
            ExecuteEvents.Execute(item, new PointerEventData(EventSystem.current), action);
        }
    }

    private void TriggerExitAction(GameObject[] objectsToTrigger, ExecuteEvents.EventFunction<IPointerExitHandler> action)
    {
        foreach (var item in objectsToTrigger)
        {
            ExecuteEvents.Execute(item, new PointerEventData(EventSystem.current), action);
        }
    }

    private void TriggerBetAction(GameObject[] objectsToTrigger, string type)
    {
        foreach (var item in objectsToTrigger)
        {
            var goalButton = item.GetComponent<GoalButton>();
            if (goalButton != null)
            {
                switch (type)
                {
                    case FirstEightString: goalButton.SelectBetFirstEight(); break;
                    case SecondEightString: goalButton.SelectBetSecondEight(); break;
                    case ThirthEightString: goalButton.SelectBetThirdEight(); break;
                    case OneToTwelveString: goalButton.SelectBetOneToTwelve(); break;
                    case TwelveToTwentyFourString: goalButton.SelectBetTwelveToTwentyFour(); break;
                    case BlueString: goalButton.SelectBetBlue(); break;
                    case YellowString: goalButton.SelectBetYellow(); break;
                    case EvenString: goalButton.SelectBetEven(); break;
                    case OddString: goalButton.SelectBetOdd(); break;
                    default: Debug.LogWarning("Unhandled type: " + type); break;
                }
            }
        }
    }

    private void TriggerPointerEnter(GameObject[] objectsToTrigger) => TriggerEnterAction(objectsToTrigger, ExecuteEvents.pointerEnterHandler);
    private void TriggerPointerClick(GameObject[] objectsToTrigger, string type) => TriggerBetAction(objectsToTrigger, type);
    private void TriggerPointerExit(GameObject[] objectsToTrigger) => TriggerExitAction(objectsToTrigger, ExecuteEvents.pointerExitHandler);

    #region EventMethods

    public void FirstEightEnter() => TriggerPointerEnter(FirstEight);
    public void FirstEightClick() => TriggerPointerClick(FirstEight, FirstEightString);
    public void FirstEightExit() => TriggerPointerExit(FirstEight);

    public void SecondEightEnter() => TriggerPointerEnter(SecondEight);
    public void SecondEightClick() => TriggerPointerClick(SecondEight, SecondEightString);
    public void SecondEightExit() => TriggerPointerExit(SecondEight);

    public void ThirthEightEnter() => TriggerPointerEnter(ThirthEight);
    public void ThirthEightClick() => TriggerPointerClick(ThirthEight, ThirthEightString);
    public void ThirthEightExit() => TriggerPointerExit(ThirthEight);

    public void OneToTwelveEnter() => TriggerPointerEnter(oneToTwelve);
    public void OneToTwelveClick() => TriggerPointerClick(oneToTwelve, OneToTwelveString);
    public void OneToTwelveExit() => TriggerPointerExit(oneToTwelve);

    public void TwelveToTwentyFourEnter() => TriggerPointerEnter(TwelveToTwentyFour);
    public void TwelveToTwentyFourClick() => TriggerPointerClick(TwelveToTwentyFour, TwelveToTwentyFourString);
    public void TwelveToTwentyFourExit() => TriggerPointerExit(TwelveToTwentyFour);

    public void BlueEnter() => TriggerPointerEnter(Blue);
    public void BlueClick() => TriggerPointerClick(Blue, BlueString);
    public void BlueExit() => TriggerPointerExit(Blue);

    public void YellowEnter() => TriggerPointerEnter(Yellow);
    public void YellowClick() => TriggerPointerClick(Yellow, YellowString);
    public void YellowExit() => TriggerPointerExit(Yellow);

    public void EvenEnter() => TriggerPointerEnter(Even);
    public void EvenClick() => TriggerPointerClick(Even, EvenString);
    public void EvenExit() => TriggerPointerExit(Even);

    public void OddEnter() => TriggerPointerEnter(Odd);
    public void OddClick() => TriggerPointerClick(Odd, OddString);
    public void OddExit() => TriggerPointerExit(Odd);

    #endregion
}
