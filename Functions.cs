﻿/**
* @peojct
* @brief This functinos are used by batch scheduling service of CloudBread 
* @author Dae Woo Kim
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Specialized;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Practices.TransientFaultHandling;
using Microsoft.Practices.EnterpriseLibrary.WindowsAzure.TransientFaultHandling.SqlAzure;
//using CloudBread_Scheduler.globals;

namespace CloudBread_Scheduler
{
    /// @brief this class is scheuder queue message format
    public class CBBatchJob
    {
        public string JobID { get; set; }
        public string JobTitle { get; set; }
        public string JobTriggerDT { get; set; }
        public string JobTrackID { get; set; }
    }

    public class Functions
    {
        public static string CBSchedulerDBConnectionString = ConfigurationManager.ConnectionStrings["CBSchedulerDBConnectionString"].ConnectionString;
        public static int CloudBreadconRetryCount = int.Parse(ConfigurationManager.AppSettings["CloudBreadconRetryCount"]);
        public static int CloudBreadconRetryFromSeconds = int.Parse(ConfigurationManager.AppSettings["CloudBreadconRetryFromSeconds"]);
        public static string CBNotiSlackChannel = ConfigurationManager.AppSettings["CBNotiSlackChannel"];
        public static string CBNotiSlackUserName = ConfigurationManager.AppSettings["CBNotiSlackUserName"];

        public static void CBProcessQueueMessage([QueueTrigger("cloudbread-batch")] CBBatchJob bj, int dequeueCount)
        {
            try
            {
                Console.WriteLine("CB task Starting {0} at CBProcessQueueMessage", bj.JobID);

                /// Database connection retry policy
                RetryPolicy retryPolicy = new RetryPolicy<SqlAzureTransientErrorDetectionStrategy>(CloudBreadconRetryCount, TimeSpan.FromSeconds(CloudBreadconRetryFromSeconds));

                switch (bj.JobID)
                {
                    case "CDBatch-DAU":

                        using (SqlConnection connection = new SqlConnection(CBSchedulerDBConnectionString))
                        {
                            using (SqlCommand command = new SqlCommand("sspBatchDAU", connection))
                            {
                                connection.OpenWithRetry(retryPolicy);
                                command.ExecuteNonQueryWithRetry(retryPolicy);
                            }
                            connection.Close();
                        }
                        break;

                    case "CDBatch-DARPU":

                        using (SqlConnection connection = new SqlConnection(CBSchedulerDBConnectionString))
                        {
                            using (SqlCommand command = new SqlCommand("sspBatchDARPU", connection))
                            {
                                connection.OpenWithRetry(retryPolicy);
                                command.ExecuteNonQueryWithRetry(retryPolicy);
                            }
                            connection.Close();
                        }
                        break;

                    case "CDBatch-Dormant":

                        using (SqlConnection connection = new SqlConnection(CBSchedulerDBConnectionString))
                        {
                            using (SqlCommand command = new SqlCommand("sspBatchDormant", connection))
                            {
                                connection.OpenWithRetry(retryPolicy);
                                command.ExecuteNonQueryWithRetry(retryPolicy);
                            }
                            connection.Close();
                        }
                        break;

                    case "CDBatch-DPA":

                        using (SqlConnection connection = new SqlConnection(CBSchedulerDBConnectionString))
                        {
                            using (SqlCommand command = new SqlCommand("sspBatchDPA", connection))
                            {
                                connection.OpenWithRetry(retryPolicy);
                                command.ExecuteNonQueryWithRetry(retryPolicy);
                            }
                            connection.Close();
                        }
                        break;

                    case "CDBatch-DPU":

                        using (SqlConnection connection = new SqlConnection(CBSchedulerDBConnectionString))
                        {
                            using (SqlCommand command = new SqlCommand("sspBatchDPU", connection))
                            {
                                connection.OpenWithRetry(retryPolicy);
                                command.ExecuteNonQueryWithRetry(retryPolicy);
                            }
                            connection.Close();
                        }
                        break;

                    case "CDBatch-FPC":

                        using (SqlConnection connection = new SqlConnection(CBSchedulerDBConnectionString))
                        {
                            using (SqlCommand command = new SqlCommand("sspBatchFPC", connection))
                            {
                                connection.OpenWithRetry(retryPolicy);
                                command.ExecuteNonQueryWithRetry(retryPolicy);
                            }
                            connection.Close();
                        }
                        break;

                    case "CDBatch-FPU":

                        using (SqlConnection connection = new SqlConnection(CBSchedulerDBConnectionString))
                        {
                            using (SqlCommand command = new SqlCommand("sspBatchFPU", connection))
                            {
                                connection.OpenWithRetry(retryPolicy);
                                command.ExecuteNonQueryWithRetry(retryPolicy);
                            }
                            connection.Close();
                        }
                        break;

                    case "CDBatch-MAU":

                        using (SqlConnection connection = new SqlConnection(CBSchedulerDBConnectionString))
                        {
                            using (SqlCommand command = new SqlCommand("sspBatchMAU", connection))
                            {
                                connection.OpenWithRetry(retryPolicy);
                                command.ExecuteNonQueryWithRetry(retryPolicy);
                            }
                            connection.Close();
                        }
                        break;

                    case "CDBatch-MPU":

                        using (SqlConnection connection = new SqlConnection(CBSchedulerDBConnectionString))
                        {
                            using (SqlCommand command = new SqlCommand("sspBatchMPU", connection))
                            {
                                connection.OpenWithRetry(retryPolicy);
                                command.ExecuteNonQueryWithRetry(retryPolicy);
                            }
                            connection.Close();
                        }
                        break;

                    case "CDBatch-WAU":

                        using (SqlConnection connection = new SqlConnection(CBSchedulerDBConnectionString))
                        {
                            using (SqlCommand command = new SqlCommand("sspBatchWAU", connection))
                            {
                                connection.OpenWithRetry(retryPolicy);
                                command.ExecuteNonQueryWithRetry(retryPolicy);
                            }
                            connection.Close();
                        }
                        break;

                    case "CDBatch-WPU":

                        using (SqlConnection connection = new SqlConnection(CBSchedulerDBConnectionString))
                        {
                            using (SqlCommand command = new SqlCommand("sspBatchWPU", connection))
                            {
                                connection.OpenWithRetry(retryPolicy);
                                command.ExecuteNonQueryWithRetry(retryPolicy);
                            }
                            connection.Close();
                        }
                        break;

                    case "CDBatch-BPI":

                        using (SqlConnection connection = new SqlConnection(CBSchedulerDBConnectionString))
                        {
                            using (SqlCommand command = new SqlCommand("sspBatchBPI", connection))
                            {
                                connection.OpenWithRetry(retryPolicy);
                                command.ExecuteNonQueryWithRetry(retryPolicy);
                            }
                            connection.Close();
                        }
                        break;

                    case "CDBatch-HAU":

                        using (SqlConnection connection = new SqlConnection(CBSchedulerDBConnectionString))
                        {
                            using (SqlCommand command = new SqlCommand("sspBatchHAU", connection))
                            {
                                connection.OpenWithRetry(retryPolicy);
                                command.ExecuteNonQueryWithRetry(retryPolicy);
                            }
                            connection.Close();
                        }
                        break;
                    case "test":
                        Console.WriteLine("CB test done {0} at CBProcessQueueMessage", bj.JobID);
                        break;
                    default:
                        break;
                }

                Console.WriteLine("CB task done {0} at CBProcessQueueMessage", bj.JobID);

                string title = bj.JobID + " task done at " + bj.JobTriggerDT + ". track #" + bj.JobTrackID;
                string body = "task info \n" + JsonConvert.SerializeObject(bj);

                /// send slack and email 
                CBNotification.SendSlackMsg(CBNotiSlackChannel, title, CBNotiSlackUserName);
                // CBNotification.SendEmail(title, body);   /// TODO : setting on app.config?
            }

            catch (Exception ex)
            {

                throw ex;
            }

        }

        //////////////////////////////////////////////////////////////
        /// @brief Timer trigger of testProcess. one time test on startup and every two min(set it "0 */2 * * * *") . trigger
        //////////////////////////////////////////////////////////////
        public static void testProcess([TimerTrigger("0 */5 * * * *", RunOnStartup = true)] TimerInfo timer)
        {
            try
            {
                Console.WriteLine("CB test timer starting");

                CBBatchJob bj = new CBBatchJob();
                bj.JobID = "test";
                bj.JobTitle = "this is developer test job";
                bj.JobTriggerDT = DateTimeOffset.UtcNow.ToString();
                bj.JobTrackID = Guid.NewGuid().ToString();

                /// send message to cloudbread-batch queue
                /// Azure Queue Storage connection retry policy
                var queueStorageRetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(2), 10);
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureWebJobsStorage"].ConnectionString);
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                queueClient.DefaultRequestOptions.RetryPolicy = queueStorageRetryPolicy;
                CloudQueue queue = queueClient.GetQueueReference("cloudbread-batch");
                queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(bj)));

                Console.WriteLine("CB test timer done");

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// Timer trigger of CBProcessHAUTrigger 
        public static void CBProcessHAUTrigger([TimerTrigger("0 10 * * * *")] TimerInfo timer)
        {
            try
            {
                Console.WriteLine("CB task timer starting at CBProcessHAUTrigger");

                CBBatchJob bj = new CBBatchJob();
                bj.JobID = "CDBatch-HAU";
                bj.JobTitle = "Hourly Active User Batch";
                bj.JobTriggerDT = DateTimeOffset.UtcNow.ToString();
                bj.JobTrackID = Guid.NewGuid().ToString();

                /// send message to cloudbread-batch queue
                /// Azure Queue Storage connection retry policy
                var queueStorageRetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(2), 10);
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureWebJobsStorage"].ConnectionString);
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                queueClient.DefaultRequestOptions.RetryPolicy = queueStorageRetryPolicy;
                CloudQueue queue = queueClient.GetQueueReference("cloudbread-batch");
                queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(bj)));

                Console.WriteLine("CB task timer done at CBProcessHAUTrigger");

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// Timer trigger of CBProcessDAU_DARPUTrigger
        public static void CBProcessDAU_DARPUTrigger([TimerTrigger("0 5 12 * * *")] TimerInfo timer) // every day 12:05 
        {
            try
            {
                Console.WriteLine("CB task timer starting at CBProcessDAU_DARPUTrigger");

                // send message to cloudbread-batch queue
                /// Azure Queue Storage connection retry policy
                var queueStorageRetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(2), 10);
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureWebJobsStorage"].ConnectionString);
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                queueClient.DefaultRequestOptions.RetryPolicy = queueStorageRetryPolicy;
                CloudQueue queue = queueClient.GetQueueReference("cloudbread-batch");

                /// send message to queue - DAU
                CBBatchJob bj = new CBBatchJob();
                bj.JobID = "CDBatch-DAU";
                bj.JobTitle = "Daily Active User Batch";
                bj.JobTriggerDT = DateTimeOffset.UtcNow.ToString();
                bj.JobTrackID = Guid.NewGuid().ToString();
                queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(bj)));

                /// send message to queue - DARPU
                bj.JobID = "CDBatch-DARPU";
                bj.JobTitle = "Daily ARPU Batch";
                bj.JobTriggerDT = DateTimeOffset.UtcNow.ToString();
                bj.JobTrackID = Guid.NewGuid().ToString();
                queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(bj)));

                Console.WriteLine("CB task timer done at CBProcessDAU_DARPUTrigger");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        /// Timer trigger of CBProcessDormantTrigger
        public static void CBProcessDormantTrigger([TimerTrigger("0 5 12 * * *")] TimerInfo timer) // every day 12:05 
        {
            try
            {
                Console.WriteLine("CB task timer starting at CBProcessDormantTrigger");

                // send message to cloudbread-batch queue
                /// Azure Queue Storage connection retry policy
                var queueStorageRetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(2), 10);
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureWebJobsStorage"].ConnectionString);
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                queueClient.DefaultRequestOptions.RetryPolicy = queueStorageRetryPolicy;
                CloudQueue queue = queueClient.GetQueueReference("cloudbread-batch");

                /// send message to queue - Dormant
                CBBatchJob bj = new CBBatchJob();
                bj.JobID = "CDBatch-Dormant";
                bj.JobTitle = "Dormant Users Batch";
                bj.JobTriggerDT = DateTimeOffset.UtcNow.ToString();
                bj.JobTrackID = Guid.NewGuid().ToString();
                queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(bj)));

                Console.WriteLine("CB task timer done at CBProcessDormantTrigger");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        /// Timer trigger of CBProcessDPA_DPUTrigger
        public static void CBProcessDPA_DPUTrigger([TimerTrigger("0 5 12 * * *")] TimerInfo timer) // every day 12:05 
        {
            try
            {
                Console.WriteLine("CB task timer starting at CBProcessDPA_DPUTrigger");

                // send message to cloudbread-batch queue
                /// Azure Queue Storage connection retry policy
                var queueStorageRetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(2), 10);
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureWebJobsStorage"].ConnectionString);
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                queueClient.DefaultRequestOptions.RetryPolicy = queueStorageRetryPolicy;
                CloudQueue queue = queueClient.GetQueueReference("cloudbread-batch");

                /// send message to queue - DPA
                CBBatchJob bj = new CBBatchJob();
                bj.JobID = "CDBatch-DPA";
                bj.JobTitle = "Daily Paying Amount Batch";
                bj.JobTriggerDT = DateTimeOffset.UtcNow.ToString();
                bj.JobTrackID = Guid.NewGuid().ToString();
                queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(bj)));

                /// send message to queue - DPU
                bj.JobID = "CDBatch-DPU";
                bj.JobTitle = "Daily Paying User Batch";
                bj.JobTriggerDT = DateTimeOffset.UtcNow.ToString();
                bj.JobTrackID = Guid.NewGuid().ToString();
                queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(bj)));

                Console.WriteLine("CB task timer done at CBProcessDPA_DPUTrigger");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        /// Timer trigger of CBProcessFPC_FPUTrigger
        public static void CBProcessFPC_FPUTrigger([TimerTrigger("0 5 12 * * *")] TimerInfo timer) // every day 12:05 
        {
            try
            {
                Console.WriteLine("CB task timer starting at CBProcessFPC_FPUTrigger");

                // send message to cloudbread-batch queue
                /// Azure Queue Storage connection retry policy
                var queueStorageRetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(2), 10);
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureWebJobsStorage"].ConnectionString);
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                queueClient.DefaultRequestOptions.RetryPolicy = queueStorageRetryPolicy;
                CloudQueue queue = queueClient.GetQueueReference("cloudbread-batch");

                /// send message to queue - FPC
                CBBatchJob bj = new CBBatchJob();
                bj.JobID = "CDBatch-FPC";
                bj.JobTitle = "First Purchase Conversion Batch";
                bj.JobTriggerDT = DateTimeOffset.UtcNow.ToString();
                bj.JobTrackID = Guid.NewGuid().ToString();
                queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(bj)));

                /// send message to queue - FPU
                bj.JobID = "CDBatch-FPU";
                bj.JobTitle = "First-time Paying User Batch";
                bj.JobTriggerDT = DateTimeOffset.UtcNow.ToString();
                bj.JobTrackID = Guid.NewGuid().ToString();
                queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(bj)));

                Console.WriteLine("CB task timer done at CBProcessFPC_FPUTrigger");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        /// Timer trigger of CBProcessMAU_MPUTrigger
        public static void CBProcessMAU_MPUTrigger([TimerTrigger("0 5 12 * * *")] TimerInfo timer) // every day 12:05 
        {
            try
            {
                Console.WriteLine("CB task timer starting at CBProcessMAU_MPUTrigger");

                // send message to cloudbread-batch queue
                /// Azure Queue Storage connection retry policy
                var queueStorageRetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(2), 10);
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureWebJobsStorage"].ConnectionString);
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                queueClient.DefaultRequestOptions.RetryPolicy = queueStorageRetryPolicy;
                CloudQueue queue = queueClient.GetQueueReference("cloudbread-batch");

                /// send message to queue - MAU
                CBBatchJob bj = new CBBatchJob();
                bj.JobID = "CDBatch-MAU";
                bj.JobTitle = "Monthly Active User Batch";
                bj.JobTriggerDT = DateTimeOffset.UtcNow.ToString();
                bj.JobTrackID = Guid.NewGuid().ToString();
                queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(bj)));

                /// send message to queue - MPU
                bj.JobID = "CDBatch-MPU";
                bj.JobTitle = "Monthly Paying User Batch";
                bj.JobTriggerDT = DateTimeOffset.UtcNow.ToString();
                bj.JobTrackID = Guid.NewGuid().ToString();
                queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(bj)));

                Console.WriteLine("CB task timer done at CBProcessMAU_MPUTrigger");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        /// Timer trigger of CBProcessWAU_WPUTrigger
        public static void CBProcessWAU_WPUTrigger([TimerTrigger("0 5 12 * * *")] TimerInfo timer) // every day 12:05 
        {
            try
            {
                Console.WriteLine("CB task timer starting at CBProcessWAU_WPUTrigger");

                // send message to cloudbread-batch queue
                /// Azure Queue Storage connection retry policy
                var queueStorageRetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(2), 10);
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureWebJobsStorage"].ConnectionString);
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                queueClient.DefaultRequestOptions.RetryPolicy = queueStorageRetryPolicy;
                CloudQueue queue = queueClient.GetQueueReference("cloudbread-batch");

                /// send message to queue - WAU
                CBBatchJob bj = new CBBatchJob();
                bj.JobID = "CDBatch-WAU";
                bj.JobTitle = "Weekly Active User Batch";
                bj.JobTriggerDT = DateTimeOffset.UtcNow.ToString();
                bj.JobTrackID = Guid.NewGuid().ToString();
                queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(bj)));

                /// send message to queue - WPU
                bj.JobID = "CDBatch-WPU";
                bj.JobTitle = "Weekly Paying User Batch";
                bj.JobTriggerDT = DateTimeOffset.UtcNow.ToString();
                bj.JobTrackID = Guid.NewGuid().ToString();
                queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(bj)));

                Console.WriteLine("CB task timer done at CBProcessWAU_WPUTrigger");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        /// Timer trigger of CBProcessBPITrigger
        public static void CBProcessBPITrigger([TimerTrigger("0 5 12 * * *")] TimerInfo timer) // every day 12:05 
        {
            try
            {
                Console.WriteLine("CB task timer starting at CBProcessBPITrigger");

                // send message to cloudbread-batch queue
                /// Azure Queue Storage connection retry policy
                var queueStorageRetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(2), 10);
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureWebJobsStorage"].ConnectionString);
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                queueClient.DefaultRequestOptions.RetryPolicy = queueStorageRetryPolicy;
                CloudQueue queue = queueClient.GetQueueReference("cloudbread-batch");

                /// send message to queue - Dormant
                CBBatchJob bj = new CBBatchJob();
                bj.JobID = "CDBatch-BPI";
                bj.JobTitle = "Best Purchased Item Batch";
                bj.JobTriggerDT = DateTimeOffset.UtcNow.ToString();
                bj.JobTrackID = Guid.NewGuid().ToString();
                queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(bj)));

                Console.WriteLine("CB task timer done at CBProcessBPITrigger");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

    }
}
