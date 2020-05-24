using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
  public class Student : IEntity<int>

    {
        public int id { get; set; }
        public string name { get; set; }
        public int GroupId { get; set; }
      

    }
}
