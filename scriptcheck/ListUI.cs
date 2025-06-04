using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Windows;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ListUI : MonoBehaviour
{
    public TMP_Text ShelterAvailability, PorridgeAvailability, SoupAvailability, SandwichAvailability;
    public TMP_Text RemainingShelter, RemainingPorridge, RemainingSoup, RemainingSandwich;
    public TMP_InputField ShelterTaken, PorridgeTaken, SoupTaken, SandwichTaken;

    private int TotalShelterSpots = 30;
    private int TotalPorridge = 15;
    private int TotalSoup = 15;
    private int TotalSandwich = 15;
    public Button SaveButton;
    // Start is called before the first frame update
    void Start()
    {
        ShelterTaken.text = "0";
        PorridgeTaken.text = "0";
        SoupTaken.text = "0";
        SandwichTaken.text = "0";

        RemainingShelter.text = TotalShelterSpots.ToString();
        RemainingPorridge.text = TotalPorridge.ToString();
        RemainingSoup.text = TotalSoup.ToString();
        RemainingSandwich.text = TotalSandwich.ToString();

        UpdateAvailability();

        
        ShelterTaken.onEndEdit.AddListener(delegate { ValidateInput(ShelterTaken, TotalShelterSpots); });
        PorridgeTaken.onEndEdit.AddListener(delegate { ValidateInput(PorridgeTaken, TotalPorridge); });
        SoupTaken.onEndEdit.AddListener(delegate { ValidateInput(SoupTaken, TotalSoup); });
        SandwichTaken.onEndEdit.AddListener(delegate { ValidateInput(SandwichTaken, TotalSandwich); });
        
    }

    void ValidateInput(TMP_InputField InputField, int MaxValue)
    {
        if (int.TryParse(InputField.text, out int value))
        {
            value = Mathf.Clamp(value, 0, MaxValue);
            InputField.text = value.ToString();
        }
        else
        {
            InputField.text = "0";
        }
        UpdateAvailability();
    }

    // Update is called once per frame
    void UpdateAvailability()
    {
        int ShelterTakenAmount = TryParseField(ShelterTaken);
        int PorridgeTakenAmount = TryParseField(PorridgeTaken);
        int SoupTakenAmount = TryParseField(SoupTaken);
        int SandwichTakenAmount = TryParseField(SandwichTaken);

        int RemainingShelter = TotalShelterSpots - ShelterTakenAmount;
        int RemainingPorridge = TotalPorridge - PorridgeTakenAmount;
        int RemainingSoup = TotalSoup - SoupTakenAmount;
        int RemainingSandwich = TotalSandwich - SandwichTakenAmount;


        if(RemainingShelter > 0) //shelter
        {
            ShelterAvailability.text = "Check";
        }
        else
        {
            ShelterAvailability.text = "Cross";
        }

        if(RemainingPorridge > 0) //porridge
        {
            PorridgeAvailability.text = "Check";
        }
        else
        {
            PorridgeAvailability.text = "Cross";
        }

        if(RemainingSoup > 0) //soup
        {
            SoupAvailability.text = "Check";
        }
        else
        {
            SoupAvailability.text = "Cross";
        }

        if(RemainingSandwich > 0)//sandwich
        {
            SandwichAvailability.text = "Check";
        }
        else
        {
            SandwichAvailability.text = "Cross";
        }
    }

    public void SaveChanges()
    {
        int ShelterTakenAmount = TryParseField(ShelterTaken);
        int PorridgeTakenAmount = TryParseField(PorridgeTaken);
        int SoupTakenAmount = TryParseField(SoupTaken);
        int SandwichTakenAmount = TryParseField(SandwichTaken);

        TotalShelterSpots = Mathf.Max(0, TotalShelterSpots - ShelterTakenAmount);
        TotalPorridge = Mathf.Max(0, TotalPorridge - PorridgeTakenAmount);
        TotalSoup = Mathf.Max(0, TotalSoup - SoupTakenAmount);
        TotalSandwich = Mathf.Max(0, TotalSandwich - SandwichTakenAmount);

        ShelterTaken.text = "0";
        PorridgeTaken.text = "0";
        SoupTaken.text = "0";
        SandwichTaken.text = "0";

        RemainingShelter.text = TotalShelterSpots.ToString();
        RemainingPorridge.text = TotalPorridge.ToString();
        RemainingSoup.text = TotalSoup.ToString();
        RemainingSandwich.text = TotalSandwich.ToString();

        UpdateAvailability();
    }

    int TryParseField(TMP_InputField Field)
    {
        return int.TryParse(Field.text, out int result) ? result : 0;
    }
}













