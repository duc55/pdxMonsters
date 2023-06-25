using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        ClickManager.Instance.SetMouseOverEnemy(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ClickManager.Instance.SetMouseOverEnemy(false);
    }
}
