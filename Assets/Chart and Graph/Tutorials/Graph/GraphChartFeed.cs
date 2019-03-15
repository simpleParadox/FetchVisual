using UnityEngine;
using ChartAndGraph;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.Linq;
using System.Runtime;
using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;


public class GraphChartFeed : MonoBehaviour
{
    private static readonly string endpointString = "https://simpleparadox.documents.azure.com:443/";
    private static readonly string authKeyString = "mjJ6AhqsNJzogLrQPW872NIT5JmowVomjW85GQ3m9WAFQ05IN0o2Ez3XMe0OcqWoDHJ3bXCu4JaNVkUlfhaDcA==";
    private static readonly string databaseId = "Tasks";
    private static readonly string collectionId = "Items";
    DocumentClient documentClient;
    GraphChartBase graph;

    void Start()
    {
        try
        {
            graph = GetComponent<GraphChartBase>();
            documentClient = new DocumentClient(new Uri(endpointString), authKeyString);
            //Task.Run(TestTableConnection);
        }
        catch (Exception e)
        {
            print("Some error occured: " + e.Message);
        }
        
    }
    private async Task TestTableConnection()
    {

        var collectionLink = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
        FeedResponse<dynamic> response = await documentClient.ReadDocumentFeedAsync(collectionLink);

        //var res = response.ElementAt<dynamic>(-1);
        //print(res);

        // string data = response;
        //var res = JsonConvert.DeserializeObject(response);
        // print(res);
        //var res = 1;
        //foreach (var doc in response)
        //{
        //    //print(doc);
        //    res = doc;
        //}
        //print("Hello world!");
        //print(res);

        if (graph != null)
        {
            graph.DataSource.StartBatch();
            graph.DataSource.ClearCategory("Player 1");
            graph.DataSource.ClearAndMakeBezierCurve("Player 2");
            for (int i = 0; i < 30; i++)
            {
                graph.DataSource.AddPointToCategory("Player 1", UnityEngine.Random.value * 10f, UnityEngine.Random.value * 10f + 20f);
                if (i == 0)
                    graph.DataSource.SetCurveInitialPoint("Player 2", 0f, UnityEngine.Random.value * 10f + 10f);
                else
                    graph.DataSource.AddLinearCurveToCategory("Player 2",
                                                                    new DoubleVector2(i * 10f / 30f, UnityEngine.Random.value * 10f + 10f));
            }

            graph.DataSource.MakeCurveCategorySmooth("Player 2");
            graph.DataSource.EndBatch();
        }
    }
    private void Update()
   { 
        Task.Run(TestTableConnection);
    }
}