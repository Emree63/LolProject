using DTO;
using Model;

namespace ApiLol.Mapper.enums
{
    public static class CategoryMapper
    {
        public static RunePageDto.CategoryDto ToDto(this RunePage.Category category)
        {
            switch (category)
            {
                case RunePage.Category.Major:
                    return RunePageDto.CategoryDto.Major;
                case RunePage.Category.Minor1:
                    return RunePageDto.CategoryDto.Minor1;
                case RunePage.Category.Minor2:
                    return RunePageDto.CategoryDto.Minor2;
                case RunePage.Category.Minor3:
                    return RunePageDto.CategoryDto.Minor3;
                case RunePage.Category.OtherMinor1:
                    return RunePageDto.CategoryDto.OtherMinor1;
                case RunePage.Category.OtherMinor2:
                    return RunePageDto.CategoryDto.OtherMinor2;
                default:
                    return RunePageDto.CategoryDto.Major;
            }
        }

        public static RunePage.Category ToModel(this RunePageDto.CategoryDto category)
        {
            switch (category)
            {
                case RunePageDto.CategoryDto.Major:
                    return RunePage.Category.Major;
                case RunePageDto.CategoryDto.Minor1:
                    return RunePage.Category.Minor1;
                case RunePageDto.CategoryDto.Minor2:
                    return RunePage.Category.Minor2;
                case RunePageDto.CategoryDto.Minor3:
                    return RunePage.Category.Minor3;
                case RunePageDto.CategoryDto.OtherMinor1:
                    return RunePage.Category.OtherMinor1;
                case RunePageDto.CategoryDto.OtherMinor2:
                    return RunePage.Category.OtherMinor2;
                default:
                    return RunePage.Category.Major;
            }
        }
    }
}
