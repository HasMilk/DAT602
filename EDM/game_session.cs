//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class game_session
    {
        public game_session()
        {
            this.npc_game_session = new HashSet<npc_game_session>();
            this.player_game_session = new HashSet<player_game_session>();
        }
    
        public int Game_Session_ID { get; set; }
        public int Game_ID { get; set; }
        public System.DateTime Game_Start_Time { get; set; }
        public Nullable<System.DateTime> Game_End_Time { get; set; }
    
        public virtual game game { get; set; }
        public virtual ICollection<npc_game_session> npc_game_session { get; set; }
        public virtual ICollection<player_game_session> player_game_session { get; set; }
    }
}
