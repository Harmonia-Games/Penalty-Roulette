using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
public class Ball : MonoBehaviour
{
    public Transform curvePosition;
    public Transform targetPosition;
    public Animator fileAnim;
    

    public void MoveWithCurve()
    {
        // Eğri için kontrol noktalarını belirleyin
        Vector3 startPoint = transform.position;
        Vector3 controlPoint = curvePosition.position;
        Vector3 endPoint = targetPosition.position;

        // Eğrisel hareketi başlatın
        transform.DOPath(new Vector3[] { startPoint, controlPoint, endPoint }, 0.5f, PathType.CatmullRom, PathMode.TopDown2D)
            .SetEase(Ease.OutQuad);

        StartCoroutine(Goal());
    }
    IEnumerator Goal()
    {
        yield return new WaitForSeconds(0.4f);
        fileAnim.SetTrigger("Goal");
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
}
