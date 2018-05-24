using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRoster
{
    public abstract class BaseObject
    {
        /// <summary>
        /// Maps the data from a data set.
        /// </summary>
        /// <param name="dataSet">The Data set to be mapped.</param>
        /// <returns>Returns false.</returns>
        public virtual bool MapData(DataSet dataSet)
        {
            return false;
        }

        /// <summary>
        /// Maps the data from a Data Table.
        /// </summary>
        /// <param name="table">The Data Table to be mapped.</param>
        /// <returns>Returns false.</returns>
        public virtual bool MapData(DataTable table)
        {
            return false;
        }

        /// <summary>
        /// Maps the data from a Data row.
        /// </summary>
        /// <param name="row">The Data Row to be mapped.</param>
        /// <returns>Returns false.</returns>
        public virtual bool MapData(DataRow row)
        {
            return false;
        }
    }
}
