using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

[System.Serializable]
public class AssetReferenceAudioClip : AssetReferenceT<AudioClip>
{
    public AssetReferenceAudioClip(string guid) : base(guid){}
}
public class AddressableAsset : MonoBehaviour
{
    [SerializeField] private AssetReferenceGameObject _assetReference;
    [SerializeField] private AssetReferenceAudioClip _assetReferenceAudioClip;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _assetReference.LoadAssetAsync<GameObject>().Completed += (asyncOperationHandleComplete) =>
            {
                if (asyncOperationHandleComplete.Status == AsyncOperationStatus.Succeeded)
                {
                    Instantiate(asyncOperationHandleComplete.Result);
                }
                else
                {
                    Debug.LogError("Failed to Load.");
                }
            };
        }
    }

/*    private void AsyncOperationHandleComplete(AsyncOperationHandle<GameObject> asyncOperationHandle)
    {
        if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(asyncOperationHandle.Result);
        }
        else
        {
            Debug.LogError("Failed to Load.");
        }
    }*/
}
