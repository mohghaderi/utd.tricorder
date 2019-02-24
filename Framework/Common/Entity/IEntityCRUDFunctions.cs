using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;

namespace Framework.Common
{
    /// <summary>
    /// Enables crud information for a layer service
    /// </summary>
    public interface IEntityCRUDFunctions
    {

        /// <summary>
        /// Inserts the specified parameters.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="parameters">The parameters.</param>
        void Insert(object entitySet, InsertParameters parameters);



        /// <summary>
        /// Updates the specified parameters.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="parameters">The parameters.</param>
        void Update(object entitySet, UpdateParameters parameters);



        /// <summary>
        /// Deletes the specified entity set.
        /// It doesn't delete weak entititied included here, unless database does it using integrity rules
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="parameters">The parameters.</param>
        void Delete(object entitySet, DeleteParameters parameters);


        /// <summary>
        /// Gets all the records. It shouldn't be used unless the table has a few records for sure
        /// </summary>
        /// <returns></returns>
        IList GetAll();


        /// <summary>
        /// Gets the by filter.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        IList GetByFilter(GetByFilterParameters parameters);


        /// <summary>
        /// Gets the by ID.
        /// </summary>
        /// <param name="ketValues">The ket values.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        object GetByID(object ketValues, GetByIDParameters parameters);

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        long GetCount(FilterExpression filter);

        /// <summary>
        /// Gets the maximum value of a column filter by an specified filter
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        object GetMax(string columnName, FilterExpression filter);

        /// <summary>
        /// Gets the minimum value of a column filter by an specified filter
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        object GetMin(string columnName, FilterExpression filter);

        /// <summary>
        /// Gets the avgerage value of a column filter by an specified filter
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        double GetAvg(string columnName, FilterExpression filter);

    }





}
