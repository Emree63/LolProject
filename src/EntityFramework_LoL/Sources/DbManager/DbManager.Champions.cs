﻿using Model;

namespace DbManager
{
    public partial class DbManager
    {
        public class ChampionsManager : IChampionsManager
        {
            private readonly DbManager parent;

            public ChampionsManager(DbManager parent)
                => this.parent = parent;

            public Task<Champion?> AddItem(Champion? item)
            {
                throw new NotImplementedException();
            }

            public Task<bool> DeleteItem(Champion? item)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Champion?>> GetItemByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Champion?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Champion?>> GetItemsByCharacteristic(string charName, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Champion?>> GetItemsByClass(ChampionClass championClass, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Champion?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Champion?>> GetItemsByRunePage(RunePage? runePage, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Champion?>> GetItemsBySkill(Skill? skill, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Champion?>> GetItemsBySkill(string skill, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItems()
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItemsByCharacteristic(string charName)
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItemsByClass(ChampionClass championClass)
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItemsByName(string substring)
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItemsByRunePage(RunePage? runePage)
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItemsBySkill(Skill? skill)
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItemsBySkill(string skill)
            {
                throw new NotImplementedException();
            }

            public Task<Champion?> UpdateItem(Champion? oldItem, Champion? newItem)
            {
                throw new NotImplementedException();
            }
        }
    }
}
