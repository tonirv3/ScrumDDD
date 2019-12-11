using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumDDD.Domain
{
    public interface  IUnitOfWork
    {
        void Commit();
    }
}
