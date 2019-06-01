using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using AutoMapper;

namespace DevCodeCamp.Api.App_Start
{
    public static class AutoMapperConfig
    {
        public static void ConfigureMappings(UnityContainer container)
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.ConstructServicesUsing((type) =>
                {
                    return container.Resolve(type);

                });
            });
        }
    }
}
