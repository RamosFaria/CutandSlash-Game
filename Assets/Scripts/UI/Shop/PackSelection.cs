using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PackSelection : MonoBehaviour
{
    [HideInInspector] public int currentPackSelected = 0;
    private int currentPack;

    [Header("Buttons")]
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button BuyButton;
    [SerializeField] private Button SelectButton;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI selectText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI playerCoinsText;
    

    [Header("Others")]
    [SerializeField] private Blade blade;
    public List<Packs> packs;

    private void Awake()
    {


        for (int i = 0; i < packs.Count; i++)
        {
            GameObject GO = Instantiate(packs[i].ObjectDisplay, transform);
            GO.SetActive(false);
            
        }

        
    }

    private void OnEnable()
    {
        currentPack = 0;
        SelectPack(0);
    }

    private void SelectPack(int index)
    {
        previousButton.interactable = (index != 0);
        nextButton.interactable = (index != transform.childCount - 1);

        for (int i = 0; i < packs.Count; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
        
        UpdateUI();

    }

    private void UpdateUI()
    {
        if (packs[currentPack].Unlocked)
        {
            SelectButton.interactable = CurrentGameData.ChoosenPack != currentPack;
            SelectButton.gameObject.SetActive(true);
            BuyButton.gameObject.SetActive(false);
            selectText.text = "Select";
        }
        else if(currentPack == currentPackSelected)
        {
            SelectButton.interactable = false;
            SelectButton.gameObject.SetActive(true);
            BuyButton.gameObject.SetActive(false);
            selectText.text = "Selected";
        }
        else
        {
            BuyButton.gameObject.SetActive(true);
            SelectButton.gameObject.SetActive(false);
            priceText.text = packs[currentPack].Price.ToString();

            BuyButton.interactable = CurrentGameData.PlayerTotalCoins >= packs[currentPack].Price;
        }

        playerCoinsText.text = "Coins: " + CurrentGameData.PlayerTotalCoins.ToString();
    }

    public void ChangePack(int change)
    {
        currentPack += change;
        SelectPack(currentPack);
    }

    public void BuyPack()
    {
        CurrentGameData.PlayerTotalCoins -= packs[currentPack].Price;
        packs[currentPack].Unlocked = true;
        UpdateUI();
        
    }
    
    public void ConfirmPackSelection()
    {
        
        currentPackSelected = currentPack;
        CurrentGameData.ChoosenPack = currentPackSelected;        
        UpdateUI();
        CurrentGameData.packSelected = packs[CurrentGameData.ChoosenPack];
        
    }
}
