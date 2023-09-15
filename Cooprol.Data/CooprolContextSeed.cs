using System.Globalization;
using System;
using System.Reflection;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.Extensions.Logging;
using Cooprol.Data.Models;
namespace  Cooprol.Data;

public class CooprolContextSeed 
{
    public static async Task SeedAsync(CooprolContext context, ILoggerFactory loggerFactory) 
    {
        try
        {
            var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if(!context.Producers.Any())
            {
                using(var readerProducers = new StreamReader(ruta+@"/Csvs/Producer.csv"))
                {
                    using(var csvProducers  = new CsvReader(readerProducers,CultureInfo.InvariantCulture)){
                        var producers = csvProducers.GetRecord<Producer>();
                        context.Producers.AddRange(producers);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if(!context.Bills.Any())
            {
                using(var readerBills = new StreamReader(ruta+@"/Csvs/Bill.csv"))
                {
                    using(var csvBills  = new CsvReader(readerBills,CultureInfo.InvariantCulture)){
                        var lBills = csvBills.GetRecords<Bill>();
                        List<Bill> bills = new List<Bill>();
                        foreach (var item in lBills)
                        {
                            bills.Add(new Bill{
                                Id = item.Id,
                                lProduced = item.lProduced,
                                deductions = item.deductions,
                                toPay = item.toPay,
                                idProducer = item.idProducer
                            });
                        }
                        context.Bills.AddRange(bills);
                        await context.SaveChangesAsync();
                    }
                }
            }
        }catch(Exception ex)
        {
            var logger = loggerFactory.CreateLogger<CooprolContextSeed>();
            logger.LogError(ex.Message);
        }
    }
}