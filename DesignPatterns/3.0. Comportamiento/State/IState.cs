using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns._3._0._Comportamiento.State
{
    public interface IState
    {
        public void Handle(CustomerContext customerContext, decimal amount);
    }
}
