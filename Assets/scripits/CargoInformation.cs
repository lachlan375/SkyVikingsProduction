using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class CargoInformation : MonoBehaviour
{
    public string CargoDesnation;
    public GameObject theCargo; 
	public int CargoAmount;
    public CargoVaule thevalue;
    public int cargoLeft;
    public int startingAmount;
     
    public void destoyself()
    {
        Destroy(gameObject);
    }
    public void steallcargo()
    {
    if(CargoAmount >1)
        {
        CargoAmount -= 1;
        cargoLeft = CargoAmount/startingAmount*100;
        }
        

    } 
}
