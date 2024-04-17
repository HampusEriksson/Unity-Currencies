using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System;
using TMPro;
using System.Threading.Tasks;


public class UIManager : MonoBehaviour
{
    private PriceManager priceManager;
    public TextMeshProUGUI bitcoinPriceText;
    // Start is called before the first frame update
    void Start()
    {
        priceManager = GameObject.Find("PriceManager").GetComponent<PriceManager>();
               
        
    }

    // Update is called once per frame
    void Update()
    {
        // For every currency in the dictionary, display the price
        Dictionary<string, float> bitcoinPrices = priceManager.GetBitcoinPrices();
        string text = "";
        foreach (KeyValuePair<string, float> entry in bitcoinPrices)
        {
           text += entry.Key + ": " + entry.Value + "\n";
        }
        bitcoinPriceText.text = text;

        
        
    }


    
}
