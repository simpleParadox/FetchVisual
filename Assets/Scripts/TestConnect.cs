using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using Microsoft.Azure.Documents.Linq;
using System.Linq;
using System.Runtime;

public class TestConnect : MonoBehaviour
{
    private static readonly string endpointString = "https://simpleparadox.documents.azure.com:443/";
    private static readonly string authKeyString = "mjJ6AhqsNJzogLrQPW872NIT5JmowVomjW85GQ3m9WAFQ05IN0o2Ez3XMe0OcqWoDHJ3bXCu4JaNVkUlfhaDcA==";
    private static readonly string databaseId = "Tasks";
    private static readonly string collectionId = "Items";
    DocumentClient documentClient;
    void Start() {
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
        //Database database = await documentClient.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(databaseId));
        //if (database == null)
        //{
        //    Write code to create a database
        //    print("Database does not exists!");
        //}
        //else
        //{
        //    print("This is the returned database:" + database + "\n");
        //}
        var collectionLink = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
        //var response = await documentClient.ReadDocumentFeedAsync(collectionLink);
        //foreach (var doc in response)
        //{
        //    print(doc);
        //}

        // Trying out new things.
        print("Initiating sql query!");
        var response = documentClient.CreateDocumentQuery(collectionLink, "SELECT TOP 1 c.name,c.category FROM c ORDER BY c._ts DESC").ToList();
        var document = response.First();
        print(document);
    }

    void Update()
    {
        
    }
}
