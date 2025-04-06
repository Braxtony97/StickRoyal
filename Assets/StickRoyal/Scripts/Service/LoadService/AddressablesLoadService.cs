using UnityEngine;

public class AddressablesLoadService  : ILoadService
{
    public void Load(object data)
    {
        if (data is string assetName)
        {
            Debug.Log("Addressable Service");
        }
    }
}