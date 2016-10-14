using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordTeacher
{
    public interface IConnect
    {
        string AddString(string table, params string[] array);
        string GetFieldValueById(string table, string field, int id);
        string SetFieldValueById(string table, int id, string field, string value);
        int GetMaxId(string table);
        string Connect(string commandText, string GetOrSet);

    }
}
