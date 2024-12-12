using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainHoppers.Core.Domain
{
    public enum ProfileStatus
    {
        Alive,Dead,Terminated
    }
    public class PlayerProfile
    {
        public Guid ID { get; set; }
        public Guid ApplicationUserID { get; set; }
        public string ScreenName { get; set; }
        public int GoldenCarrots { get; set; }
        public int Carrots { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public List<AbilityOwnership> MyAbilities { get; set; }
        public ProfileStatus CurrentStatus { get; set; }
        public bool ProfileType { get; set; }

        // db
        public DateTime ProfileCreatedAt { get; set; }
        public DateTime ProfileModifiedAt { get; set; }
        public DateTime ProfileAttributedToAnAccountUserAt { get; set; }
        public DateTime ProfileStatusLastChangedAt { get; set; }
    }
}
