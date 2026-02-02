using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiducia.Domain.Interfaces;
using Fiducia.Domain.Enums;
using Fiducia.Domain.Services;
using Fiducia.Domain.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace Fiducia.Application.Factories
{
    public class AmortizationFactory(IServiceProvider serviceProvider) : IAmortizationFactory
    {
        public IAmortizationCalculator CreateCalculator(TypeOfAmortizationEnum type)
        {
            switch (type)
            {
                case TypeOfAmortizationEnum.French:
                    return serviceProvider.GetRequiredService<FrenchAmortizationCalculator>();
                case TypeOfAmortizationEnum.German:
                    throw TypeOfAmortizationException.NotImplemented(type.ToString());
                default:
                    throw TypeOfAmortizationException.NotFound(type.ToString());
            }
        }
    }
}
