using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrailSelection : MonoBehaviour
{
    [HideInInspector]public int currentTrailSelected = 0;
    private int currentTrail;


    [Header("Buttons")]
    [SerializeField]private Button previousButton;
    [SerializeField]private Button nextButton;
    [SerializeField]private Button BuyButton;
    [SerializeField]private Button SelectButton;
    
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI selectText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI playerCoinsText;

    [Header("Others")]
    public Blade blade;
    public List<Trails> trailsColors;

    private void Awake()
    {
        for (int i = 0; i < trailsColors.Count; i++)
        {
            GameObject GO = Instantiate(trailsColors[i].ObjectDisplay, transform);
            GO.SetActive(false);
            
        }
    }

    private void OnEnable()
    {
        currentTrail = 0;
        SelectTrail(0);
    }

    private void SelectTrail(int index)
    {
        previousButton.interactable = (index != 0);
        nextButton.interactable = (index != transform.childCount - 1);

        for(int i=0; i< trailsColors.Count; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }

        
        UpdateUI();

    }

    private void UpdateUI()
    {
        if (trailsColors[currentTrail].Unlocked)
        {
            SelectButton.interactable = blade.bladeTrailPrefab != trailsColors[currentTrail].Trail;
            SelectButton.gameObject.SetActive(true);
            BuyButton.gameObject.SetActive(false);
            selectText.text = "Select";
        }
        else if(currentTrail == CurrentGameData.ChoosenTrail)
        {
            SelectButton.interactable = false;
            SelectButton.gameObject.SetActive(true);
            BuyButton.gameObject.SetActive(false);
            selectText.text = "Selected";
        }
        else if(!trailsColors[currentTrail].Unlocked)
        {
            BuyButton.gameObject.SetActive(true);
            SelectButton.gameObject.SetActive(false);
            priceText.text = trailsColors[currentTrail].Price.ToString();

            BuyButton.interactable = CurrentGameData.PlayerTotalCoins >= trailsColors[currentTrail].Price;
        }

        playerCoinsText.text = "Coins: " + CurrentGameData.PlayerTotalCoins.ToString();
    }

    public void ChangeTrail(int change)
    {
        currentTrail += change;
        SelectTrail(currentTrail);
        
    }

    public void BuyTrail()
    {
        CurrentGameData.PlayerTotalCoins -= trailsColors[currentTrail].Price;
        trailsColors[currentTrail].Unlocked = true;
        UpdateUI();
        CurrentGameData.TrailsUnlocked.Clear();
        for(int i =0;i<trailsColors.Count;i++)
        {
            CurrentGameData.TrailsUnlocked.Add(trailsColors[i].Unlocked);
        }
    }
    
    public void ConfirmTrailSelection()
    {
        currentTrailSelected = currentTrail;
        blade.bladeTrailPrefab = trailsColors[currentTrailSelected].Trail;
        CurrentGameData.ChoosenTrail = currentTrailSelected;
        UpdateUI();
        
    }
}
