using System;

namespace EntityMaker
{
    internal interface IGenerator
    {
        Tuple<bool, string> Initilize(string constr);
        Tuple<bool, string> Generate(string tableName);
    }
}