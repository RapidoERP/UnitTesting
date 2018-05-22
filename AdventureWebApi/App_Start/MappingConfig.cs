#region Using
using AutoMapper;
#endregion

namespace AdventureWebApi
{
    public class MappingConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(config =>
            {
                // Add all automapper profiles within the current assembly (profiles can be found in the AutoMapper folder). 
                config.AddProfiles(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
                
            });
        }
    }
}