using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Feature.MediatR.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureAvailableToFalseCommand:IRequest
    {
        public int CarFeatureId { get; set; }

        public UpdateCarFeatureAvailableToFalseCommand(int carFeatureId)
        {
            CarFeatureId = carFeatureId;
        }
    }
}
