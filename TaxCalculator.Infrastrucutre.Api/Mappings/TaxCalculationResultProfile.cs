using AutoMapper;
using TaxCalculator.Domain.Services.Commands;
using TaxCalculator.Infrastructure.Api.Models;

namespace TaxCalculator.Infrastructure.Api.Mappings;

public class TaxCalculationResultProfile : Profile
{
    public TaxCalculationResultProfile()
    {
        CreateMap<CalculateTaxCommand.Reply, TaxCalculationResponse>()
            .ForMember(dest => dest.GrossAnnualSalary, 
                opt => opt.MapFrom(src => Math.Round(src.GrossAnnualSalary, 2)))
            .ForMember(dest => dest.GrossMonthlySalary, 
                opt => opt.MapFrom(src => Math.Round(src.GrossMonthlySalary, 2)))
            .ForMember(dest => dest.AnnualTax, 
                opt => opt.MapFrom(src => Math.Round(src.AnnualTax, 2)))
            .ForMember(dest => dest.MonthlyTax, 
                opt => opt.MapFrom(src => Math.Round(src.MonthlyTax, 2)))
            .ForMember(dest => dest.NetMonthlySalary, 
                opt => opt.MapFrom(src => Math.Round(src.NetMonthlySalary, 2)))
            .ForMember(dest => dest.NetAnnualSalary, 
                opt => opt.MapFrom(src => Math.Round(src.NetAnnualSalary, 2)));

        CreateMap<DataAccess.SqlDb.DbModels.TaxBand, Domain.Models.TaxBand>();
    }
}