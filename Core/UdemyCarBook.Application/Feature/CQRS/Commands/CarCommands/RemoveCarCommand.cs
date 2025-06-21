﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Feature.CQRS.Commands.CarCommands
{
    public class RemoveCarCommand
    {
        public int CarId { get; set; }

        public RemoveCarCommand(int Id)
        {
            CarId = Id;
        }
    }
}
