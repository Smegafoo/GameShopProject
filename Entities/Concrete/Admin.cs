using Core.DataAccess.Entities;
using Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Admin : IEntity

    {
        public int Id { get; set; }
        public string AdminName { get; set; }
        public Authority AdminLevel { get; set; }
    }
}
