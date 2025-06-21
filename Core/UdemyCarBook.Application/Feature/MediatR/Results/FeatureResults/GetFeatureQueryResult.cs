using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.MediatR.Results.FeatureResults
{
    public class GetFeatureQueryResult
    {
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
    }
}
