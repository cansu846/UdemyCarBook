using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Feature.MediatR.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureAvailableToTrueCommand:IRequest
    {
        public int CarFeatureId { get; set; }

        public UpdateCarFeatureAvailableToTrueCommand(int carFeatureId)
        {
            CarFeatureId = carFeatureId;
        }
    }
}
