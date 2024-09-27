using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFStudio.Common.Utils;
using Oculus.Platform;
using Oculus.Platform.Models;
using UnityEngine;
using Application = UnityEngine.Application;

namespace AFStudio.XR.Oculus
{
    public class MetaAdapter : IMetaAdapter
    {
        public async Task<bool> PerformEntitlementCheck()
        {
            var tcs = new TaskCompletionSource<bool>();
            try
            {
                Core.AsyncInitialize();
                Entitlements.IsUserEntitledToApplication().OnComplete((msg) =>
                {
                    if (msg.IsError) // User failed entitlement check
                    {
                        // Implements a default behavior for an entitlement check failure -- log the failure and exit the app.
                        ApeLog.Error("You are NOT entitled to use this app.");
                        Application.Quit();
                        tcs.SetResult(false);
                    }
                    else // User passed entitlement check
                    {
                        // Log the succeeded entitlement check for debugging.
                        ApeLog.Log("You are entitled to use this app.");
                        tcs.SetResult(true);
                    }
                });
            }
            catch (UnityException e)
            {
                ApeLog.Error("Platform failed to initialize due to exception.");
                Debug.LogException(e);
                // Immediately quit the application.
                Application.Quit();
                tcs.SetResult(false);
            }

            return await tcs.Task;
        }

        public Task<User> PerformLogin()
        {
            var tcs = new TaskCompletionSource<User>();
            try
            {
                Users.GetLoggedInUser().OnComplete((msg) =>
                {
                    if (msg.IsError)
                    {
                        ApeLog.Error("Error getting logged in user: " + msg.GetError().Message);
                        tcs.SetResult(null);
                        return;
                    }
                    
                    ApeLog.Log($"Logged in as {msg.Data.OculusID}.");
                    
                    tcs.SetResult(msg.Data);
                });
            }
            catch (Exception e)
            {
                ApeLog.Exception(e);
                tcs.SetResult(null);
            }

            return tcs.Task;
        }

        public async Task<IList<AchievementDefinition>> GetAchievementDefs()
        {
            var tcs = new TaskCompletionSource<IList<AchievementDefinition>>();
            try
            {
                Achievements.GetAllDefinitions().OnComplete((msg) =>
                {
                    if (msg.IsError)
                    {
                        ApeLog.Error("Error getting achievement definitions: " + msg.GetError().Message);
                        tcs.SetResult(null);
                        return;
                    }
                    
                    ApeLog.Log($"Received {msg.Data.Count} achievement definitions.");
                    
                    tcs.SetResult(msg.Data);
                });
            }
            catch (Exception e)
            {
                ApeLog.Exception(e);
                tcs.SetResult(null);
            }

            return await tcs.Task;
        }
        
        public async Task<IList<AchievementProgress>> GetAchievementProgress()
        {
            var tcs = new TaskCompletionSource<IList<AchievementProgress>>();
            try
            {
                Achievements.GetAllProgress().OnComplete((msg) =>
                {
                    if (msg.IsError)
                    {
                        ApeLog.Error("Error getting achievement progress: " + msg.GetError().Message);
                        tcs.SetResult(null);
                        return;
                    }
                    
                    ApeLog.Log($"Received {msg.Data.Count} achievement progress.");
                    
                    tcs.SetResult(msg.Data);
                });
            }
            catch (Exception e)
            {
                ApeLog.Exception(e);
                tcs.SetResult(null);
            }

            return await tcs.Task;
        }
        
        public async Task<Leaderboard> GetLeaderboard(string leaderboardID)
        {
            var tcs = new TaskCompletionSource<Leaderboard>();
            try
            {
                Leaderboards.Get(leaderboardID).OnComplete((msg) =>
                {
                    if (msg.IsError)
                    {
                        ApeLog.Error("Error getting leaderboard: " + msg.GetError().Message);
                        tcs.SetResult(null);
                        return;
                    }
                    
                    ApeLog.Log($"Received leaderboard {leaderboardID}.");
                    
                    tcs.SetResult(msg.Data.FirstOrDefault());
                });
            }
            catch (Exception e)
            {
                ApeLog.Exception(e);
                tcs.SetResult(null);
            }

            return await tcs.Task;
        }
        
        public async Task<IList<LeaderboardEntry>> GetLeaderboardEntries(string leaderboardID)
        {
            var tcs = new TaskCompletionSource<IList<LeaderboardEntry>>();
            try
            {
                Leaderboards.GetEntries(leaderboardID, 50, LeaderboardFilterType.None, LeaderboardStartAt.CenteredOnViewerOrTop).OnComplete((msg) =>
                {
                    if (msg.IsError)
                    {
                        ApeLog.Error("Error getting leaderboard entries: " + msg.GetError().Message);
                        tcs.SetResult(null);
                        return;
                    }
                    
                    ApeLog.Log($"Received {msg.Data.Count} leaderboard entries for {leaderboardID}.");
                    
                    tcs.SetResult(msg.Data);
                });
            }
            catch (Exception e)
            {
                ApeLog.Exception(e);
                tcs.SetResult(null);
            }

            return await tcs.Task;
        }

        public Task<bool> WriteLeaderboardEntry(string leaderboardID, int score)
        {
            var tcs = new TaskCompletionSource<bool>();
            try
            {
                Leaderboards.WriteEntry(leaderboardID, score).OnComplete((msg) =>
                {
                    if (msg.IsError)
                    {
                        ApeLog.Error("Error writing leaderboard entry: " + msg.GetError().Message);
                        tcs.SetResult(false);
                        return;
                    }
                    
                    ApeLog.Log($"Wrote leaderboard entry for {leaderboardID}.");
                    
                    tcs.SetResult(true);
                });
            }
            catch (Exception e)
            {
                ApeLog.Exception(e);
                tcs.SetResult(false);
            }

            return tcs.Task;
        }
    }
    
    public interface IMetaAdapter
    {
        Task<bool> PerformEntitlementCheck();
        Task<User> PerformLogin();
        Task<IList<AchievementDefinition>> GetAchievementDefs();
        Task<IList<AchievementProgress>> GetAchievementProgress();
        Task<Leaderboard> GetLeaderboard(string leaderboardID);
        Task<IList<LeaderboardEntry>> GetLeaderboardEntries(string leaderboardID);
        Task<bool> WriteLeaderboardEntry(string leaderboardID, int score);
    }

    public class NullAdapter : IMetaAdapter
    {
        public Task<bool> PerformEntitlementCheck()
        {
            ApeLog.Log("NullAdapter: Entitlement check skipped.");
            return Task.FromResult(true);
        }

        public Task<User> PerformLogin()
        {
            ApeLog.Log("NullAdapter: Login skipped.");
            return Task.FromResult<User>(null);
        }

        public async Task<IList<AchievementDefinition>> GetAchievementDefs()
        {
            ApeLog.Log("NullAdapter: GetAchievementDefs skipped.");
            return await Task.FromResult(new List<AchievementDefinition>());
        }

        public Task<IList<AchievementProgress>> GetAchievementProgress()
        {
            ApeLog.Log("NullAdapter: GetAchievementProgress skipped.");
            return Task.FromResult<IList<AchievementProgress>>(null);
        }

        public Task<Leaderboard> GetLeaderboard(string leaderboardID)
        {
            ApeLog.Log("NullAdapter: GetLeaderboard skipped.");
            return Task.FromResult<Leaderboard>(null);
        }

        public Task<IList<LeaderboardEntry>> GetLeaderboardEntries(string leaderboardID)
        {
            ApeLog.Log("NullAdapter: GetLeaderboardEntries skipped.");
            return Task.FromResult<IList<LeaderboardEntry>>(null);
        }

        public Task<bool> WriteLeaderboardEntry(string leaderboardID, int score)
        {
            ApeLog.Log("NullAdapter: WriteLeaderboardEntry skipped.");
            return Task.FromResult(true);
        }
    }
    
    public static class MetaAdapterFactory
    {
        public static IMetaAdapter Create()
        {
            #if !UNITY_EDITOR
            return new MetaAdapter();
            #else
            return new NullAdapter();
            #endif
        }
    }
}