﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.Interfaces
{
    public interface ICustomLogger
    {
        public void LogError(string message);
    }
}
