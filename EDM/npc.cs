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
    
    public partial class npc
    {
        public npc()
        {
            this.npc_game_session = new HashSet<npc_game_session>();
        }
    
        public int NPC_ID { get; set; }
        public string NPC_Name { get; set; }
        public int NPC_Type { get; set; }
    
        public virtual ICollection<npc_game_session> npc_game_session { get; set; }
    }
}
