using System;
using System.Collections.Generic;

namespace Fibon.Api.FibbonRepository
{
    public class InMemoryRepository : IRepository
    {
        private readonly Dictionary<int, int> _storage = new Dictionary<int, int>();

        void IRepository.Add(int number, int result)
        {
            _storage[number] = result;
        }

        int? IRepository.Get(int number)
        {
            int value;
            if(_storage.TryGetValue(number, out value))
            {
                return value;
            }
            return null;
        }
    }
}