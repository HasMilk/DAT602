//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class player_game_session
    {
        public int Game_Session_ID { get; set; }
        public int Player_ID { get; set; }
        public int Player_X { get; set; }
        public int Player_Y { get; set; }
        public int Player_Hits { get; set; }
        public int Player_Misses { get; set; }
    
        public virtual game_session game_session { get; set; }
        public virtual player player { get; set; }
    }
}
