using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets; //Let's us use addresables
using UnityEngine.ResourceManagement.AsyncOperations; // Let's us use ASync Operations

public class SpawnAddresableObjects : MonoBehaviour
{
    [SerializeField] private AssetLabelReference rem;
    // Start is called before the first frame update
    void Start()
    {
        Addressables.LoadAssetAsync<GameObject>(rem).Completed += ASynceOperationCompleted; // Loads the addresable with the provided 
        //string address and subscribes to the completed call to call the ASyncOperationCompleted Method 
        
    }

    private void ASynceOperationCompleted(AsyncOperationHandle<GameObject> asyncoperationhandle)//Checks if asyncoperation has succeeded in loading the addresable asset
    {
        if(asyncoperationhandle.Status == AsyncOperationStatus.Succeeded)//Instiates asset if yes
        {
            Instantiate(asyncoperationhandle.Result);
        }
        else//through debug log is no
        {
            Debug.Log("Failed to Load");
        }
    }

}
