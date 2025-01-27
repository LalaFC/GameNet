using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableAsset : MonoBehaviour
{
    public AssetReference assetReference; // Drag your addressable reference here
    private GameObject instantiatedObject;

    // Instantiate the Addressable object
    public void InstantiateAddressableObject()
    {
        // Load the Addressable asynchronously
        Addressables.InstantiateAsync(assetReference).Completed += OnAddressableInstantiated;
    }

    private void OnAddressableInstantiated(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            instantiatedObject = obj.Result; // Get the instantiated object
            Debug.Log("Object instantiated!");
        }
        else
        {
            Debug.LogError("Failed to instantiate Addressable!");
        }
    }

    // Destroy the instantiated object and release the Addressable
    public void DestroyAddressableObject()
    {
        if (instantiatedObject != null)
        {
            // Release the Addressable asset from memory
            Addressables.Release(instantiatedObject);

            // Destroy the instantiated object
            Destroy(instantiatedObject);
            Debug.Log("Object destroyed!");
        }
        else
        {
            Debug.LogWarning("No object to destroy.");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InstantiateAddressableObject();
        }
        else if (Input.GetKeyDown(KeyCode.Backspace)) { DestroyAddressableObject(); }
    }
}
