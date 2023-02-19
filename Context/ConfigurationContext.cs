using BuggyCars_SpecFlow.Models;
using Microsoft.Extensions.Configuration;

namespace BuggyCars_SpecFlow.Context;

public class ConfigurationContext
{
    public ConfigurationInfo configuration { get; set; } = new();

    public ConfigurationContext()
    {
        var config = new ConfigurationBuilder().AddJsonFile("config.json", optional: false).Build();

        this.configuration = config.Get<ConfigurationInfo>() ?? 
            throw new ApplicationException("Unable to get configuration");
    }
}
