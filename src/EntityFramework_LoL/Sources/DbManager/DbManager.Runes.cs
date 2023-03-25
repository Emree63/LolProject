using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLib
{
    public partial class DbManager
    {
        public class RunesManager : IRunesManager
        {
            private readonly DbManager parent;
            public RunesManager(DbManager parent)
                => this.parent = parent;

            public Task<Model.Rune?> AddItem(Model.Rune? item)
            {
                throw new NotImplementedException();
            }

            public Task<bool> DeleteItem(Model.Rune? item)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Model.Rune?>> GetItemByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Model.Rune?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Model.Rune?>> GetItemsByFamily(RuneFamily family, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Model.Rune?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItems()
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItemsByFamily(RuneFamily family)
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItemsByName(string substring)
            {
                throw new NotImplementedException();
            }

            public Task<Model.Rune?> UpdateItem(Model.Rune? oldItem, Model.Rune? newItem)
            {
                throw new NotImplementedException();
            }
        }

    }
}
