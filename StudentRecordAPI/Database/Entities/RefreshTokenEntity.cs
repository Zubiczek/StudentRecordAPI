using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Database.Entities
{
    public class RefreshTokenEntity
    {
        public int Id { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string Token { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string User_Id { get; set; }
        public virtual UserEntity User { get; set; }
        public bool IsActive()
        {
            DateTime now = DateTime.UtcNow;
            if (now > this.ExpiresOn) return false;
            else return true;
        }
    }
}
