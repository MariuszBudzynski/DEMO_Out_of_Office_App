using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOOutOfOfficeApp.Common.Interfaces
{
    public interface IOutOfOfficeBalance
    {
        public int OutOfOfficeBalance { get; set; }
    }
}
