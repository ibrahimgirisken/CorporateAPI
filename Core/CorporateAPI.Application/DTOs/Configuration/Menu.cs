using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Configuration
{
    public class Menu
    {
        public Menu()
        {
            Actions = new List<Action>();
        }
        public string Name { get; set; }
        public List<Action> Actions { get; set; }
    }
}
