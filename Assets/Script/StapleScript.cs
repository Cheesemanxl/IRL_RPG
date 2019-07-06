using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StapleScript : MonoBehaviour
{
    private float cash = 5.0f;
    private float baseAppeal = 0.1f;
    private float currentAppeal = 0.3f;
    private float sellSuccess = 0.6f;
    private float publicDemand = 0.0f;
    private float staplePrice = 0.5f;
    private float wire = 0.0f;
    private float wireCost = 1.0f;

    private int staples = 0;
    private int costTicker = 0;
    private int sellTicker = 0;

    public Text stapleText;
    public Text cashText;
    public Text priceText;
    public Text appealText;
    public Text wireText;
    public Text wireCostText;

    void Start()
    {
        wireCost = Random.Range(1f, 5f);
        sellSuccess = Random.Range(0.0f, currentAppeal - .01f);
        SetCurrentAppeal();
        SetPublicDemand();

    }

    //Game Loop
    void FixedUpdate()
    {
        //Truncate Floats
        cash = Mathf.Round(cash * 100f) / 100f;
        publicDemand = Mathf.Round(publicDemand * 100f) / 100f;
        staplePrice = Mathf.Round(staplePrice * 100f) / 100f;
        wire = Mathf.Round(wire * 10f) / 10f;
        wireCost = Mathf.Round(wireCost * 100f) / 100f;
        
        //Update UI text
        stapleText.text = "Staples: " + staples;
        cashText.text = "Cash: $" + cash.ToString("F2");
        priceText.text = "$" + staplePrice.ToString("F2");
        appealText.text = "Public Appeal: " + publicDemand + "%";
        wireText.text = "Wire: " + wire + " inches";
        wireCostText.text = "Wire Cost: $" + wireCost.ToString("F2");
        Debug.Log(currentAppeal);
        //IDK LOL YOU FIGURE IT OUT
        SellLogic();
        SetCost();


    }

    private void SellLogic()
    {
            //Random appeal every 300frames
            if (sellTicker < 100)
            {
                sellTicker++;

            }
            else
            {
                sellSuccess = Random.value;
                sellTicker = 0;
            }

            if (sellSuccess >= currentAppeal)
            {
                if (staples > 0) {
                    staples--;
                    cash = cash + staplePrice;
                    Debug.Log("SOLD!");
                    sellSuccess = Random.Range(0.0f, currentAppeal - .01f);
                    sellTicker = 0;
                }
            }
    }

    private void SetCost()
    {
        //Random wireCost in range every 500frames
        if (costTicker < 100)
        {
            costTicker++;
        }
        else
        {
            costTicker = 0;
            wireCost = Random.Range(1f, 5f);
        }
    }

    public void UpPrice()
    {
        if (staplePrice < 1)
        {
            staplePrice = staplePrice + 0.01f;
            SetCurrentAppeal();
            SetPublicDemand();
        }
    }

    public void DownPrice()
    {
        if (staplePrice > 0) {
            staplePrice = staplePrice - 0.01f;
            SetCurrentAppeal();
            SetPublicDemand();
        }
    }

    public void MakeStaple()
    {
        if (wire > 0)
        {
            staples++;
            wire = wire - 0.1f;
        }
    }

    public void BuyWire()
    {

        if (cash > wireCost)
        {
            wire = wire + 10f;
            cash = cash - wireCost;
        }
    }
    
    private void SetPublicDemand()
    {
        publicDemand = (currentAppeal * 1000f);
    }

    private void SetCurrentAppeal()
    {
        currentAppeal = ((2.0f - staplePrice) * baseAppeal);
    }

}
