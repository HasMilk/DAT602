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
    
    public partial class game
    {
        public game()
        {
            this.game_session = new HashSet<game_session>();
        }
    
        public int Game_ID { get; set; }
        public string Game_Name { get; set; }
        public int Game_Type { get; set; }
        public int Game_TTL { get; set; }
    
        public virtual ICollection<game_session> game_session { get; set; }
    }
}