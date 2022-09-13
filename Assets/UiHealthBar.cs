using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHealthBar : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    
    public Image foregorund;
    public Image baclground;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
    }

    public void SetHealthPercentage(float percent)
    {
        float parentWidth = GetComponentInParent<RectTransform>().rect.width;
        float width = parentWidth * percent;
        foregorund.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
    }
}
