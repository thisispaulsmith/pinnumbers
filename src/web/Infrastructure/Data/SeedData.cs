using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Web.Infrastructure.Data
{
    public class SeedData
    {
        public async Task SeedAsync(PinDataContext context)
        {
            if (!context.PinNumbers.Any())
            {
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
                                    context.PinNumbers.Add(new Models.PinNumber()
                                    {
                                        Pin = pin
                                    });
                                    
                                }
                            }
                        }
                    }
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
