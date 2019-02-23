using EFCore.BulkExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Infrastructure.Data
{
    public class SeedData
    {
        public async Task SeedAsync(PinDataContext context)
        {
            if (!context.PinNumbers.Any())
            {
                var list = new List<PinNumber>(9990);

                for (int a = 0; a < 10; a++)
                {
                    for (int b = 0; b < 10; b++)
                    {
                        for (int c = 0; c < 10; c++)
                        {
                            for (int d = 0; d < 10; d++)
                            {
                                var pin = $"{a}{b}{c}{d}";

                                if (!Regex.IsMatch(pin, @"(\d)\1{3}"))
                                {
                                    list.Add(new PinNumber()
                                    {
                                        Pin = pin
                                    });
                                }
                            }
                        }
                    }
                }

                await context.BulkInsertAsync(list);
            }
        }
    }
}
