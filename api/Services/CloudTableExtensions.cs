using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace aspnetCoreReactTemplate.Services
{
    public static class CloudTableExtensions
    {
        /// <summary>
        /// Calls CloudTable.ExecuteQuerySegmentedAsync until all results are returned and returns the complete list when finished
        /// 
        /// Microsoft removed CloudTable.ExecuteQuery from the public API for .NET Standard, leaving ExecuteQuerySegmentedAsync as the only
        /// available query method in .NET Standard/Core and didn't document it anywhere other than a comment on a Github Issue.
        /// https://github.com/Azure/azure-storage-net/issues/407
        /// </summary>
        /// <param name="cloudTable"></param>
        /// <param name="tableQuery"></param>
        /// <returns></returns>
        public static async Task<IList<T>> ExecuteQueryAsync<T>(this CloudTable cloudTable, TableQuery<T> tableQuery) where T : ITableEntity, new() {
            List<T> queryResults = new List<T>();
            TableContinuationToken continuationToken = null;
            
            do
            {
                // Retrieve a segment (up to 1,000 entities).
                TableQuerySegment<T> tableQueryResult =
                    await cloudTable.ExecuteQuerySegmentedAsync(tableQuery, continuationToken);

                // Assign the new continuation token to tell the service where to
                // continue on the next iteration (or null if it has reached the end).
                continuationToken = tableQueryResult.ContinuationToken;

                queryResults.AddRange(tableQueryResult.Results);

            // Loop until a null continuation token is received, indicating the end of the table.
            } while(continuationToken != null);

            return queryResults;
        }
    }
}