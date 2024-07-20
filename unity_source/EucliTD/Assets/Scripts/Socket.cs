using UnityEngine;

public class Socket : MonoBehaviour
{
    public GameObject purchasePopUp;

    void Start()
    {

    }

    void OpenSelection()
    {
        purchasePopUp.SetActive(true);
    }

    void CloseSelection()
    {
        purchasePopUp.SetActive(false);
    }

    void SetPurchased()
    {

    }
}
