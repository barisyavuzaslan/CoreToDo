using CoreProject.ToDo.EntitiesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.EntitiesLayer.Concrete
{
    public class Urgency : ITable
    {
        public int Id { get; set; }
        public string Definition { get; set; }

        public List<Process> Processes { get; set; }
    }
}
