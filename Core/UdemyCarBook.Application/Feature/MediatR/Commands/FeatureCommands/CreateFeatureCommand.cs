using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Feature.MediatR.Commands.FeatureCommands
{
    public class CreateFeatureCommand:IRequest
    {
        public string FeatureName { get; set; }
    }
}
