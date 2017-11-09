using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CargoVaule {Common,Uncommon,Rare}
public class ObjectPriceList : MonoBehaviour

{
    public int CommonVaule;
    public int UncommonVale;
    public int RareVaule;
    public int maxCargo;
    public PlaySatSheat cargosats;
    void Start()
    {
        cargosats = FindObjectOfType<PlaySatSheat>();
         foreach (StatsBace item in cargosats.TheStats)
        {

            if (item.StatName == "maxCargo")
            {
                   maxCargo = item.statInt;
            }
        }

    }
}
