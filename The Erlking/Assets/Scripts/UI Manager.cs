using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public FearManager fearManager;

    public Image fearBar;

    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void UpdateFear(int fear)
    {
        fearBar.fillAmount = fear / fearManager.getMaxFear();
    }
}
