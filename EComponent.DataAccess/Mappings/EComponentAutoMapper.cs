using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace EComponent.DataAccess.Mappings
{
    public class EComponentAutoMapper
    {
        /// <summary>
        /// Initialize method
        /// </summary>
        public static void Initialize()
        {
            Mapper.Initialize(x => Configure(Mapper.Configuration));
            //To see if there are any mapping errors uncomment the line below and run in debug mode.
            //Mapper.AssertConfigurationIsValid();
        }

        /// <summary>
        /// Configure profiles
        /// </summary>
        /// <param name="configuration"></param>
        public static void Configure(IConfiguration configuration)
        {
            configuration.AddProfile(Activator.CreateInstance(typeof(MappingProfiles)) as Profile);
        }
    }
}
