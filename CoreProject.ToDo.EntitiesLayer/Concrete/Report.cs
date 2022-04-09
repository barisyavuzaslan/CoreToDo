using CoreProject.ToDo.EntitiesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.EntitiesLayer.Concrete
{
    public class Report : ITable
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public string Details { get; set; }

        public int ProcessId { get; set; }
        public Process Process { get; set; }
    }
}
