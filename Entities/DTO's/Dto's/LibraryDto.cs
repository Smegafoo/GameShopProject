using Core.Dto;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO_s.Dto_s
{
    public class LibraryDto  :IDto
    {
    
        public Game game {  get; set; }
        

        public LibraryDto()
        {
            
        }


    }
}
