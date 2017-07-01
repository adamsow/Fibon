using System;

namespace Fibon.Api.FibbonRepository
{
    public interface IRepository
    {
         void Add(int number, int result);

         int? Get (int number);

    }
}