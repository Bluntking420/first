using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
  private int basevalue;
        private int  maxvaluse;
        [SerializeField] private Image fill;
    [SerializeField] private Text Amount;
    public void SetValues(int _basevalue,int _maxvalue)
    { 
     basevalue = _basevalue;
        maxvaluse = _maxvalue;
        Amount.text=basevalue.ToString();
        CalcutaleFillAmount();
    }
    private void CalcutaleFillAmount()
    {
        float fillAmount = (float)basevalue /(float) maxvaluse;
        fill.fillAmount = fillAmount;
    }


}
