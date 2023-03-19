﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager
{
    public partial class DbManager
    {
        public class SkinsManager : ISkinsManager
        {
            private readonly DbManager parent;

            public SkinsManager(DbManager parent)
                => this.parent = parent;

            public Task<Skin?> AddItem(Skin? item)
            {
                throw new NotImplementedException();
            }

            public Task<bool> DeleteItem(Skin? item)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Skin?>> GetItemByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Skin?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Skin?>> GetItemsByChampion(Champion? champion, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Skin?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItems()
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItemsByChampion(Champion? champion)
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItemsByName(string substring)
            {
                throw new NotImplementedException();
            }

            public Task<Skin?> UpdateItem(Skin? oldItem, Skin? newItem)
            {
                throw new NotImplementedException();
            }
        }

    }
}