using System.Collections.Generic;
using System;

namespace Business
{
    public interface IVehicle<T>
    {
        IEnumerable<T> list();
    }
}