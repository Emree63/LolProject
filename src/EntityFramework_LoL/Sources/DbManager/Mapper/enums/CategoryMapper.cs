using Model;
using MyFlib.Entities.enums;

namespace DbManager.Mapper.enums
{
    public static class CategoryMapper
    {
        public static RunePage.Category ToModel(this CategoryEntity category)
        {
            switch (category)
            {
                case CategoryEntity.Major:
                    return RunePage.Category.Major;
                case CategoryEntity.Minor1:
                    return RunePage.Category.Minor1;
                case CategoryEntity.Minor2:
                    return RunePage.Category.Minor2;
                case CategoryEntity.Minor3:
                    return RunePage.Category.Minor3;
                case CategoryEntity.OtherMinor1:
                    return RunePage.Category.OtherMinor1;
                case CategoryEntity.OtherMinor2:
                    return RunePage.Category.OtherMinor2;
                default:
                    return RunePage.Category.Major;
            }
        }

        public static CategoryEntity ToEntity(this RunePage.Category category)
        {
            switch (category)
            {
                case RunePage.Category.Major:
                    return CategoryEntity.Major;
                case RunePage.Category.Minor1:
                    return CategoryEntity.Minor1;
                case RunePage.Category.Minor2:
                    return CategoryEntity.Minor2;
                case RunePage.Category.Minor3:
                    return CategoryEntity.Minor3;
                case RunePage.Category.OtherMinor1:
                    return CategoryEntity.OtherMinor1;
                case RunePage.Category.OtherMinor2:
                    return CategoryEntity.OtherMinor2;
                default:
                    return CategoryEntity.Major;
            }
        }
    }
}
