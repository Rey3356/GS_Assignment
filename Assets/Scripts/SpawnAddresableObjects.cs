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
        // Loads the addresable with the provided label and subscribes to the completed event
        //Also Utilizez Lambda function
        Addressables.LoadAssetAsync<GameObject>(rem).Completed +=
            (asyncoperationhandle) =>
            {
                if (asyncoperationhandle.Status == AsyncOperationStatus.Succeeded)
                {
                    Instantiate(asyncoperationhandle.Result);
                }
                else
                {
                    Debug.Log("Failed to Load");
                }
            };



    }

}
