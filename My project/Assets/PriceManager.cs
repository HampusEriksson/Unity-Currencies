using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class PriceManager : MonoBehaviour
{
    private Dictionary<string, float> bitcoinPrices = new Dictionary<string, float>();

    void Start()
    {
        bitcoinPrices.Add("USD", 0.0f);
        bitcoinPrices.Add("GBP", 0.0f);
        bitcoinPrices.Add("EUR", 0.0f);       

        // Start updating prices repeatedly
        StartCoroutine(UpdatePricesRepeatedly());
    }

    IEnumerator UpdatePricesRepeatedly()
    {
        while (true)
        {
            UpdatePrices();
            yield return new WaitForSeconds(10f); // Wait for 10 seconds before updating again
        }
    }

    public void UpdatePrices()
    {
        StartCoroutine(UpdateBitcoinPrice());
        StartCoroutine(UpdateEthereumPrice());
    }

    IEnumerator UpdateBitcoinPrice()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("https://api.coindesk.com/v1/bpi/currentprice.json"))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
            }
            else
            {
                string jsonString = request.downloadHandler.text;
                SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonString);

                bitcoinPrices["USD"] = data["bpi"]["USD"]["rate_float"].AsFloat;
                bitcoinPrices["GBP"] = data["bpi"]["GBP"]["rate_float"].AsFloat;
                bitcoinPrices["EUR"] = data["bpi"]["EUR"]["rate_float"].AsFloat;
            }
        }
    }

    IEnumerator UpdateEthereumPrice()
    {
        // Not implemneted yet
        yield return null;
    }
    public Dictionary<string, float> GetBitcoinPrices()
    {
        return bitcoinPrices;
    }
}
