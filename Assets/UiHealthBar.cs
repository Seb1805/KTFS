using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHealthBar : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    
    public Image foregorund;
    public Image background;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 direction = (target.position - Camera.main.transform.position).normalized;
        bool isBehind = Vector3.Dot(direction, Camera.main.transform.forward) <= 0.0f;
        foregorund.enabled = !isBehind;
        background.enabled = !isBehind;
        transform.position = Camera.main.WorldToScreenPoint(target.position + offset);
    }

    public void SetHealthPercentage(float percent)
    {
        float parentWidth = GetComponentInParent<RectTransform>().rect.width;
        float width = parentWidth * percent;
        foregorund.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
    }
}
