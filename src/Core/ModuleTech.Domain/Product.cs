using ModuleTech.Core.BaseEntities;

namespace ModuleTech.Domain;
public class Product: BaseSoftDeleteEntity
{
        public string Name { get; set; }
        public string Url { get; set; }
    }

