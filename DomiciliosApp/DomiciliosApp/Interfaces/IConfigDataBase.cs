using System;
using System.Collections.Generic;
using System.Text;

namespace DomiciliosApp.Interfaces
{
    public interface IConfigDataBase
    {
        string GetFullPath(string databaseFileName);
    }
}
