using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelController : MonoBehaviour
{
    public static FuelController instance;
    [SerializeField] private Image fuelImg;
    [SerializeField] private float maxFuel = 100f;
    [SerializeField] private Gradient fuelGradient;
    [SerializeField, Range(0.1f, 5f)] private float fuelDrainSpeed = 1f;
    private float currentFuel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentFuel = maxFuel;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        currentFuel -= Time.deltaTime * fuelDrainSpeed;
        UpdateUI();
        if(currentFuel <= 0f)
        {
            GameManager.instance.GameOver();
        }
    }

    private void UpdateUI()
    {
        fuelImg.fillAmount = (currentFuel / maxFuel);
        fuelImg.color = fuelGradient.Evaluate(fuelImg.fillAmount);
    }
}
