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
    GameObject LoadedObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _assetReference.LoadAssetAsync<GameObject>().Completed += (asyncOperationHandleComplete) =>
            {
                if (asyncOperationHandleComplete.Status == AsyncOperationStatus.Succeeded)
                {
                    //_assetReference.InstantiateAsync();
                    LoadedObject = asyncOperationHandleComplete.Result;
                    Instantiate(LoadedObject);
                    //_assetReference.ReleaseAsset();
                }
                else
                {
                    Debug.LogError("Failed to Load.");
                }
            };
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Addressables.Release(LoadedObject);
            DestroyImmediate(LoadedObject, true);
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
