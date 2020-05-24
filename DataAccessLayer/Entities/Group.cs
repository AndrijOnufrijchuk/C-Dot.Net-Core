using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Group : IEntity<int>
    {
        public int id { get; set; }
        public int group_number { get; set; }
    }
}
