using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class CargoInformation : MonoBehaviour
{
    public string CargoDesnation;
    public GameObject theCargo; 
	public int CargoAmount;
    public CargoVaule thevalue;
    public float cargoLeft;
    public float startingAmount;
    public cargoremoved cargoAni; 
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


            if (cargoLeft == 50 || cargoLeft == 25 || cargoLeft == 10)
            {
                cargoAni.play();
            }
        }       

    }
    
}
