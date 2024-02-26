using UnityEngine;

public class HealthCollBehav : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField] private float _healthAmount;

    public void OnCollected(GameObject player)
    {
        player.GetComponent<HealthController>().AddHeatlh(_healthAmount);
    }
}
