using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Transform currentZone;
    private string currentZoneTag;
    private UIManager ui;

    public bool isInActiveZone = false;
    
    
    void Start()
    {
        ui = FindFirstObjectByType<UIManager>();
    }

    void Update()
    {
        RefreshPrompt(); 

        if (currentZone == null) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentZoneTag == "Pickup")
            {
                DeliveryManager.Instance.TryPickup(currentZone);
            }
            else if (currentZoneTag == "Delivery")
            {
                DeliveryManager.Instance.TryDeliver(currentZone);
            }
            else if (currentZoneTag == "Shop")
            {
                FindFirstObjectByType<ShopUI>().OpenShop();
            
            }

            RefreshPrompt(); 
        }
    }


    void RefreshPrompt()
    {
        if (currentZone == null)
        {
            ui.SetPrompt("");
            isInActiveZone = false;
            return;
        }

        bool isActivePickup = currentZoneTag == "Pickup" && currentZone == DeliveryManager.Instance.currentPickup && DeliveryManager.Instance.currentStage == DeliveryManager.Stage.GoToPickup;

        bool isActiveDelivery = currentZoneTag == "Delivery" && currentZone == DeliveryManager.Instance.currentDelivery && DeliveryManager.Instance.currentStage == DeliveryManager.Stage.GoToDelivery;

        if (isActivePickup)
        {
            ui.SetPrompt("Press E to Pick Up");
            isInActiveZone = true;
        }
        else if (isActiveDelivery)
        {
            ui.SetPrompt("Press E to Deliver");
            isInActiveZone = true;
        }
        else if (currentZoneTag == "Shop")
        {
            ui.SetPrompt("Press E to Open Shop");
            isInActiveZone = false;
        }
        else
        {
            ui.SetPrompt("");
            isInActiveZone = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup") || other.CompareTag("Delivery") || other.CompareTag("Shop"))
        {
            currentZone = other.transform;
            currentZoneTag = other.tag;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == currentZone)
        {
            currentZone = null;
            currentZoneTag = null;
            ui.SetPrompt("");
        }
    }
}