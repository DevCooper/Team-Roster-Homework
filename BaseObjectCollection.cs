using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRoster
{
    public abstract class BaseObjectCollection<T> : List<T> where T : BaseObject, new()
    {
        /// <summary>
        /// Maps a DataSet.
        /// </summary>
        /// <param name="dataSet">The data to be mapped.</param>
        /// <returns>Returns true if the data set contains at least one table.</returns>
        public bool MapObjects(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                return MapObjects(dataSet.Tables[0]);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Maps the data from a DataTable.
        /// </summary>
        /// <param name="table">The table to be mapped.</param>
        /// <returns>Returns true. Always. Better hope that's a good table.</returns>
        public bool MapObjects(DataTable table)
        {
            this.Clear();
            for (int index = 0; index < table.Rows.Count; index++)
            {
                T obj = new T();
                obj.MapData(table.Rows[index]);
                this.Add(obj);
            }

            return true;
        }
    }
}
