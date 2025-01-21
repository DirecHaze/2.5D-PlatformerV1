using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Uimanager : MonoBehaviour
{
    [SerializeField]
    private Text _coinCount;
    [SerializeField]
    private Text _livesCount;
    
   
    public void CoinCount(int CoinGot)
    {
        _coinCount.text = "Coin:" + CoinGot;
    }
    public void LivesCount(int Lives)
    {
        _livesCount.text = "Lives:" + Lives;
    }
}
