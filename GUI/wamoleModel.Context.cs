﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAT602_GUI
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
        public DbSet<player_challenge> player_challenge { get; set; }
    
        public virtual int PlayerLogin(ObjectParameter prResult, string prPlayerName, string prPlayerPassword)
        {
            var prPlayerNameParameter = prPlayerName != null ?
                new ObjectParameter("prPlayerName", prPlayerName) :
                new ObjectParameter("prPlayerName", typeof(string));
    
            var prPlayerPasswordParameter = prPlayerPassword != null ?
                new ObjectParameter("prPlayerPassword", prPlayerPassword) :
                new ObjectParameter("prPlayerPassword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PlayerLogin", prResult, prPlayerNameParameter, prPlayerPasswordParameter);
        }
    
        public virtual int PlayerLogout(Nullable<int> prPlayerID)
        {
            var prPlayerIDParameter = prPlayerID.HasValue ?
                new ObjectParameter("prPlayerID", prPlayerID) :
                new ObjectParameter("prPlayerID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PlayerLogout", prPlayerIDParameter);
        }
    
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
    
        public virtual int LockPlayer(Nullable<int> prPlayerID)
        {
            var prPlayerIDParameter = prPlayerID.HasValue ?
                new ObjectParameter("prPlayerID", prPlayerID) :
                new ObjectParameter("prPlayerID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LockPlayer", prPlayerIDParameter);
        }
    
        public virtual int ChallengePlayer(Nullable<int> prPlayer1ID, Nullable<int> prPlayer2ID, ObjectParameter prResult)
        {
            var prPlayer1IDParameter = prPlayer1ID.HasValue ?
                new ObjectParameter("prPlayer1ID", prPlayer1ID) :
                new ObjectParameter("prPlayer1ID", typeof(int));
    
            var prPlayer2IDParameter = prPlayer2ID.HasValue ?
                new ObjectParameter("prPlayer2ID", prPlayer2ID) :
                new ObjectParameter("prPlayer2ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ChallengePlayer", prPlayer1IDParameter, prPlayer2IDParameter, prResult);
        }
    }
}