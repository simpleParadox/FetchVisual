using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.Linq;

public class TestConnect : MonoBehaviour
{
    private static readonly string endpointString = "https://simpleparadox.documents.azure.com:443/";
    private static readonly string authKeyString = "mjJ6AhqsNJzogLrQPW872NIT5JmowVomjW85GQ3m9WAFQ05IN0o2Ez3XMe0OcqWoDHJ3bXCu4JaNVkUlfhaDcA==";
    private static readonly string databaseId = "Tasks";

    DocumentClient documentClient;
    // Start is called before the first frame update
    void Start() {
        print("Entered Start!");
        try
        {
            documentClient = new DocumentClient(new Uri(endpointString), authKeyString);
            Task.Run(TestTableConnection);
        }
        catch (Exception e)
        {
            print("Some error occured: " + e.Message);
        }
    }

    private async Task TestTableConnection()
    {
        print("Entered TestTableConnection!");
        Database database = await documentClient.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(databaseId));
        print("Read database");
        if(database == null)
        {
            // Write code to create a database
            print("Database does not exists!");
        }
        else
        {
            print("This is the returned database:" + database + "\n");
        }
    }

    private async Task<List<Strength>> TestToListAsync(IMobileServiceTable<Strength> table)
    {
        
        var allEntries = await table.ToListAsync();
        foreach(var item in allEntries)
        {
            Debug.Log(item.Category);
        }
        return allEntries;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
