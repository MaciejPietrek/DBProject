using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBProject
{
    static class Methods
    {
        static public List<int> getIdFromColumnNO(int column, DataGridViewSelectedRowCollection rows)
        {
            List<int> result = new List<int>();
            foreach (DataGridViewRow x in rows)
            {
                result.Add((int)x.Cells[column].Value);
            }
            return result;
        }

        public static string GetMemberName<T>(Expression<Func<T>> memberExpression)
        {
            MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
            return expressionBody.Member.Name;
        }
    }
}
