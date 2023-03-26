using DTO;
using DTO.enums;
using Model;

namespace ApiMapping.enums
{
    public static class RuneFamilyMapper
    {
        public static RuneFamilyDto ToDto(this RuneFamily runeFamily)
        {
            switch (runeFamily)
            {
                case RuneFamily.Unknown:
                    return RuneFamilyDto.Unknown;
                case RuneFamily.Precision:
                    return RuneFamilyDto.Precision;
                case RuneFamily.Domination:
                    return RuneFamilyDto.Domination;
                default:
                    return RuneFamilyDto.Unknown;
            }
        }

        public static RuneFamily ToModel(this RuneFamilyDto runeFamily)
        {
            switch (runeFamily)
            {
                case RuneFamilyDto.Unknown:
                    return RuneFamily.Unknown;
                case RuneFamilyDto.Precision:
                    return RuneFamily.Precision;
                case RuneFamilyDto.Domination:
                    return RuneFamily.Domination;
                default:
                    return RuneFamily.Unknown;
            }
        }
    }
}
