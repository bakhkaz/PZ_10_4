﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_10_c4
{
    class Notes
    {
        public string Name { set; get; }
        public Status status { set; get; }
        public Notes(string name, Status st)
        {
            Name = name;
            status = st;
        }
    }

    public enum Status
    {
        Нужно_выполнить,
        Выполнено

    }
}
