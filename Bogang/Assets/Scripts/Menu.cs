using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Player player = null;

    public Button btnCar = null;
    public Button btnBoat = null;

    private void Start()
    {
        btnCar.onClick.AddListener(OnClickCar);
        btnBoat.onClick.AddListener(OnClickBoat);
    }

    public void OnClickCar()
    {
        Debug.Log("Ride to Car");
        player.RideTo(new Car()); 
    }

    public void OnClickBoat()
    {
        Debug.Log("Rid to Boat");
        player.RideTo(new Boat());
    }


}
