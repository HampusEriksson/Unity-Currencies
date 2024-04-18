using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AssetsManager : MonoBehaviour
{
    public TextMeshProUGUI assetsText;
    private Dictionary<string, float> assets = new Dictionary<string, float>();
    // Start is called before the first frame update
    void Start()
    {
        assets.Add("USD", 1000.0f);
        assets.Add("GBP", 0.0f);
        assets.Add("EUR", 0.0f);
        assets.Add("BTC", 0.0f);
        assets.Add("ETH", 0.0f);
        UpdateAssetsText();
    }

    private void UpdateAssetsText()
    {
        string text = "";
        foreach (KeyValuePair<string, float> entry in assets)
        {
            text += entry.Key + ": " + entry.Value + "\n";
        }
        assetsText.text = text;
    }
}
