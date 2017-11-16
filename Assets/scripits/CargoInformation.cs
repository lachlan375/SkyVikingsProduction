using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class CargoInformation : MonoBehaviour
{
    [HideInInspector]
    public string CargoDesnation;
    [Tooltip("this is just for debugging to eazly tell whos lost there stuff")]
    public string cargoName;
	public int CargoAmount;
    [Tooltip("this is for the pireats to look at")]
    public CargoVaule thevalue;
    [HideInInspector]
    public float cargoLeft;
    [HideInInspector]
        public float startingAmount;
    void OnEnable()
    {
        startingAmount = CargoAmount;
    }
         public void destoyself()
    {
        Destroy(gameObject);
    }
    public void steallcargo()
    {
    if(CargoAmount >1)
        {
        CargoAmount -= 1;
        cargoLeft = (Mathf.Round(CargoAmount / startingAmount * 100));
            Debug.Log(cargoName + cargoLeft);

            
        }       

    }
    
}
