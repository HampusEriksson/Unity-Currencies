using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine.UI;



public static class Prices
{
    public static Dictionary<string, float> bitcoinPrices = new Dictionary<string, float>();


    public static void SetupPrices()
    {
        bitcoinPrices.Add("USD", 0.0f);
        bitcoinPrices.Add("GBP", 0.0f);
        bitcoinPrices.Add("EUR", 0.0f);
    }
    public static void UpdatePrices()
    {
        GetBitcoinPrice();
    }
   

    public async static void GetBitcoinPrice()
    {
        string url = "https://api.coindesk.com/v1/bpi/currentprice.json";
     
            using (var httpClient = new HttpClient())
            {
                // Fetch data from the URL
                HttpResponseMessage response = await httpClient.GetAsync(url);

                // Check if the request was successful (status code 200)
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to fetch data. Status: {response.StatusCode}");
                }

                // Parse the JSON data
            string jsonString = await response.Content.ReadAsStringAsync();
        Debug.Log(jsonString);

        // Deserialize JSON to object
        var jsonData = JsonUtility.FromJson<BitcoinData>(jsonString);

        // Update bitcoinPrices dictionary
        bitcoinPrices["USD"] = jsonData.bpi.USD.rate_float;
        bitcoinPrices["GBP"] = jsonData.bpi.GBP.rate_float;
        bitcoinPrices["EUR"] = jsonData.bpi.EUR.rate_float;
            
        }
        }
       
}


[Serializable]
public class BitcoinData
{
    public Time time;
    public string disclaimer;
    public string chartName;
    public Bpi bpi;
}

[Serializable]
public class Time
{
    public string updated;
    public string updatedISO;
    public string updateduk;
}

[Serializable]
public class Bpi
{
    public CurrencyData USD;
    public CurrencyData GBP;
    public CurrencyData EUR;
}

[Serializable]
public class CurrencyData
{
    public string code;
    public string symbol;
    public string rate;
    public string description;
    public float rate_float;
}
