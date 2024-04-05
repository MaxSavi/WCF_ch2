using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_ch2.Models
{
    [DataContract]
    public class UserModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Password { get; set; }
        public UserModel(int id, string name, string password) { Id = id; Name = name; Password = password; }
    }
}