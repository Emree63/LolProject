using Model;
using MyFlib.Entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Mapper.enums
{
    public static class RuneFamilyMapper
    {
        public static RuneFamily ToModel(this RuneFamilyEntity runeFamily)
        {
            switch (runeFamily)
            {
                case RuneFamilyEntity.Unknown:
                    return RuneFamily.Unknown;
                case RuneFamilyEntity.Precision:
                    return RuneFamily.Precision;
                case RuneFamilyEntity.Domination:
                    return RuneFamily.Domination;
                default:
                    return RuneFamily.Unknown;
            }
        }

        public static RuneFamilyEntity ToEntity(this RuneFamily runeFamily)
        {
            switch (runeFamily)
            {
                case RuneFamily.Unknown:
                    return RuneFamilyEntity.Unknown;
                case RuneFamily.Precision:
                    return RuneFamilyEntity.Precision;
                case RuneFamily.Domination:
                    return RuneFamilyEntity.Domination;
                default:
                    return RuneFamilyEntity.Unknown;
            }
        }
    }
}
