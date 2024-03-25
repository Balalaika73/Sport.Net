using System;
using System.Collections.Generic;

namespace Sport.Models
{
    public partial class TypeRoom
    {
        public TypeRoom()
        {
            ActivityRooms = new HashSet<ActivityRoom>();
        }

        public int IdTypeRoom { get; set; }
        public string NameRoom { get; set; } = null!;
        public int MaxUsers { get; set; }
        public bool IsDeleted { get; set; }
        public string? TypeRoomPhoto { get; set; }
        public string? TypeRoomInfo { get; set; }

        public virtual ICollection<ActivityRoom> ActivityRooms { get; set; }
    }
}
