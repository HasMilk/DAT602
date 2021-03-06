﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAT602_EDM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class wamoleEntities : DbContext
    {
        public wamoleEntities()
            : base("name=wamoleEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<game> games { get; set; }
        public DbSet<game_session> game_session { get; set; }
        public DbSet<npc> npcs { get; set; }
        public DbSet<npc_game_session> npc_game_session { get; set; }
        public DbSet<player> players { get; set; }
        public DbSet<player_game_session> player_game_session { get; set; }
        public DbSet<player_score> player_score { get; set; }
        public DbSet<player_session> player_session { get; set; }
    
        public virtual int CreatePlayer(string prPlayerName, string prPlayerPassword)
        {
            var prPlayerNameParameter = prPlayerName != null ?
                new ObjectParameter("prPlayerName", prPlayerName) :
                new ObjectParameter("prPlayerName", typeof(string));
    
            var prPlayerPasswordParameter = prPlayerPassword != null ?
                new ObjectParameter("prPlayerPassword", prPlayerPassword) :
                new ObjectParameter("prPlayerPassword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreatePlayer", prPlayerNameParameter, prPlayerPasswordParameter);
        }
    
        public virtual int CreateGameSession(Nullable<int> prGameID, string prGameName)
        {
            var prGameIDParameter = prGameID.HasValue ?
                new ObjectParameter("prGameID", prGameID) :
                new ObjectParameter("prGameID", typeof(int));
    
            var prGameNameParameter = prGameName != null ?
                new ObjectParameter("prGameName", prGameName) :
                new ObjectParameter("prGameName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateGameSession", prGameIDParameter, prGameNameParameter);
        }
    
        public virtual int EndGameSession(Nullable<int> prGameSessionID)
        {
            var prGameSessionIDParameter = prGameSessionID.HasValue ?
                new ObjectParameter("prGameSessionID", prGameSessionID) :
                new ObjectParameter("prGameSessionID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EndGameSession", prGameSessionIDParameter);
        }
    
        public virtual int LeaveGameSession(Nullable<int> prGameSessionID, Nullable<int> prPlayerID)
        {
            var prGameSessionIDParameter = prGameSessionID.HasValue ?
                new ObjectParameter("prGameSessionID", prGameSessionID) :
                new ObjectParameter("prGameSessionID", typeof(int));
    
            var prPlayerIDParameter = prPlayerID.HasValue ?
                new ObjectParameter("prPlayerID", prPlayerID) :
                new ObjectParameter("prPlayerID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LeaveGameSession", prGameSessionIDParameter, prPlayerIDParameter);
        }
    
        public virtual int RemovePlayer(Nullable<int> prPlayerID)
        {
            var prPlayerIDParameter = prPlayerID.HasValue ?
                new ObjectParameter("prPlayerID", prPlayerID) :
                new ObjectParameter("prPlayerID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RemovePlayer", prPlayerIDParameter);
        }
    
        public virtual int UpdatePlayer(Nullable<int> prPlayerID, string prPlayerName, string prPlayerPassword, Nullable<int> prPlayerLoginAttempts, Nullable<sbyte> prPlayerLocked)
        {
            var prPlayerIDParameter = prPlayerID.HasValue ?
                new ObjectParameter("prPlayerID", prPlayerID) :
                new ObjectParameter("prPlayerID", typeof(int));
    
            var prPlayerNameParameter = prPlayerName != null ?
                new ObjectParameter("prPlayerName", prPlayerName) :
                new ObjectParameter("prPlayerName", typeof(string));
    
            var prPlayerPasswordParameter = prPlayerPassword != null ?
                new ObjectParameter("prPlayerPassword", prPlayerPassword) :
                new ObjectParameter("prPlayerPassword", typeof(string));
    
            var prPlayerLoginAttemptsParameter = prPlayerLoginAttempts.HasValue ?
                new ObjectParameter("prPlayerLoginAttempts", prPlayerLoginAttempts) :
                new ObjectParameter("prPlayerLoginAttempts", typeof(int));
    
            var prPlayerLockedParameter = prPlayerLocked.HasValue ?
                new ObjectParameter("prPlayerLocked", prPlayerLocked) :
                new ObjectParameter("prPlayerLocked", typeof(sbyte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdatePlayer", prPlayerIDParameter, prPlayerNameParameter, prPlayerPasswordParameter, prPlayerLoginAttemptsParameter, prPlayerLockedParameter);
        }
    
        public virtual int PlayerLogin(string prPlayerName, string prPlayerPassword, ObjectParameter prResult)
        {
            var prPlayerNameParameter = prPlayerName != null ?
                new ObjectParameter("prPlayerName", prPlayerName) :
                new ObjectParameter("prPlayerName", typeof(string));
    
            var prPlayerPasswordParameter = prPlayerPassword != null ?
                new ObjectParameter("prPlayerPassword", prPlayerPassword) :
                new ObjectParameter("prPlayerPassword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PlayerLogin", prPlayerNameParameter, prPlayerPasswordParameter, prResult);
        }
    
        public virtual int PlayerLogout(Nullable<int> prPlayerID)
        {
            var prPlayerIDParameter = prPlayerID.HasValue ?
                new ObjectParameter("prPlayerID", prPlayerID) :
                new ObjectParameter("prPlayerID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PlayerLogout", prPlayerIDParameter);
        }
    
        public virtual int RemoveScores(Nullable<int> prPlayerID)
        {
            var prPlayerIDParameter = prPlayerID.HasValue ?
                new ObjectParameter("prPlayerID", prPlayerID) :
                new ObjectParameter("prPlayerID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RemoveScores", prPlayerIDParameter);
        }
    
        public virtual int CreateNPC(string prNPCName, Nullable<int> prNPCType)
        {
            var prNPCNameParameter = prNPCName != null ?
                new ObjectParameter("prNPCName", prNPCName) :
                new ObjectParameter("prNPCName", typeof(string));
    
            var prNPCTypeParameter = prNPCType.HasValue ?
                new ObjectParameter("prNPCType", prNPCType) :
                new ObjectParameter("prNPCType", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateNPC", prNPCNameParameter, prNPCTypeParameter);
        }
    
        public virtual int RemoveGameSession(Nullable<int> prGameID)
        {
            var prGameIDParameter = prGameID.HasValue ?
                new ObjectParameter("prGameID", prGameID) :
                new ObjectParameter("prGameID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RemoveGameSession", prGameIDParameter);
        }
    
        public virtual int RemoveGame(Nullable<int> prGameID)
        {
            var prGameIDParameter = prGameID.HasValue ?
                new ObjectParameter("prGameID", prGameID) :
                new ObjectParameter("prGameID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RemoveGame", prGameIDParameter);
        }
    
        public virtual int RemoveNPC(Nullable<int> prNPCID)
        {
            var prNPCIDParameter = prNPCID.HasValue ?
                new ObjectParameter("prNPCID", prNPCID) :
                new ObjectParameter("prNPCID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RemoveNPC", prNPCIDParameter);
        }
    }
}
