using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

public class TestConnect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Task.Run(TestTableConnection);
    }

    private async Task TestTableConnection()
    {
        var table = AzureMobileServiceClient.Client.GetTable<Strength>();

        await table.InsertAsync(new Strength{Id="1", Address="1", Signal="-80"});

        await TestToListAsync(table);
    }
    
    private async Task<List<Strength>> TestToListAsync(IMobileServiceTable<Strength> table)
    {
        
        var allEntries = await table.ToListAsync();
        foreach(var item in allEntries)
        {
            Debug.Log(item.Signal);
        }
        return allEntries;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
