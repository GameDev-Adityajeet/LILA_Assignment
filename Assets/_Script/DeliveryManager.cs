using UnityEngine;
using System.Collections.Generic;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance;

    [Header("Zones (auto-found by tag)")]
    public List<Transform> pickupPoints = new List<Transform>();
    public List<Transform> deliveryPoints = new List<Transform>();

    [Header("State (read-only, for debugging)")]
    public Transform currentPickup;
    public Transform currentDelivery;
    public bool hasPackage = false;

    [Header("Difficulty Scaling")]
    public int deliveriesCompleted = 0;
    public int scaleEveryNDeliveries = 3;
    public float timeBonusReductionPerScale = 1f; 
    public float minimumTimeBonus = 3f; 
    
    public enum Stage { GoToPickup, GoToDelivery }
    public Stage currentStage;
    public GameObject deliveryBurstPrefab; 


    void Awake()
    {
        Instance = this;

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Pickup"))
            pickupPoints.Add(go.transform);

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Delivery"))
            deliveryPoints.Add(go.transform);
    }

    void Start()
    {
        StartNewDelivery();
    }

    void StartNewDelivery()
    {
        hasPackage = false;
        currentStage = Stage.GoToPickup;
        currentPickup = GetRandomExcluding(pickupPoints, currentPickup);
        currentDelivery = null;

        UIManager ui = FindFirstObjectByType<UIManager>();
        ui.SetDeliveryStatus("Go to pickup: " + currentPickup.name);
    }

    public void TryPickup(Transform zone)
    {
            if (currentStage != Stage.GoToPickup) return;
            if (zone != currentPickup) return;

            hasPackage = true;
            currentStage = Stage.GoToDelivery;
            currentDelivery = GetRandomExcluding(deliveryPoints, currentDelivery);

            AudioManager.Instance.PlayPickup();
            FindFirstObjectByType<UIManager>().SetDeliveryStatus("Deliver to: " + currentDelivery.name);
    }

    public void TryDeliver(Transform zone)
    {
        {
            if (currentStage != Stage.GoToDelivery) return;
            if (zone != currentDelivery) return;

            GameState.Instance.AddMoney(50);
            GameState.Instance.AddTimeBonus();

            AudioManager.Instance.PlayDelivery();
            CameraShake.Instance.Shake();

            if (deliveryBurstPrefab != null)
            {
                GameObject burst = Instantiate(deliveryBurstPrefab, zone.position + Vector3.up * 0.5f, Quaternion.identity);
                ParticleSystem ps = burst.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    ps.Play();
                }
            }

            deliveriesCompleted++;
            if (deliveriesCompleted % scaleEveryNDeliveries == 0)
            {
                ApplyDifficultyScale();
            }

            StartNewDelivery();
        }
    }
    
    void ApplyDifficultyScale()
    {
        float newBonus = GameState.Instance.timeBonusPerDelivery - timeBonusReductionPerScale;
        GameState.Instance.timeBonusPerDelivery = Mathf.Max(newBonus, minimumTimeBonus);

        Debug.Log("Difficulty increased! Time bonus per delivery now: " + GameState.Instance.timeBonusPerDelivery);
    }
    
    Transform GetRandomExcluding(List<Transform> list, Transform exclude)
    {
        if (list.Count <= 1) return list[0]; 

        Transform pick;
        do
        {
            pick = list[Random.Range(0, list.Count)];
        }
        while (pick == exclude);

        return pick;
    }
}