using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System;
using TMPro;
using System.Threading.Tasks;


public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI bitcoinPriceText;
    // Start is called before the first frame update
    void Start()
    {
        Prices.UpdatePrices();
        Prices.SetupPrices();
        StartCoroutine(UpdatePrices());
        
    }

    // Update is called once per frame
    void Update()
    {

        bitcoinPriceText.text = Prices.bitcoinPrices["USD"].ToString() + " $"
            + "\n" + Prices.bitcoinPrices["GBP"].ToString() + " £"
            + "\n" + Prices.bitcoinPrices["EUR"].ToString() + " €";
        
        
    }

    public IEnumerator UpdatePrices()
    {
        while (true)
        {
            Debug.Log("Updating Prices");
            yield return new WaitForSeconds(30);
            Prices.UpdatePrices();
        }
    }

    
}
