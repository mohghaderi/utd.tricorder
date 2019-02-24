using System;
using System.Collections.Generic;


namespace Framework.Common
{
    public interface IEntityCRUDFunctions<T, V>
    {
        /// <summary>
        /// Inserts the specified entity set.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="insertColumns">The insert columns.</param>
        void InsertT(T entitySet, InsertParameters parameters = null);


        /// <summary>
        /// Updates the the specified entity set.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="parameters">The parameters.</param>
        void UpdateT(T entitySet, UpdateParameters parameters = null);



        /// <summary>
        /// Deletes the specified entity set.
        /// It doesn't delete weak entititied included here, unless database does it using integrity rules
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        void DeleteT(T entitySet, DeleteParameters parameters = null);


        /// <summary>
        /// Gets all the records. It shouldn't be used unless the table has a few records for sure
        /// </summary>
        /// <returns></returns>
        IList<T> GetAllT();



        /// <summary>
        /// Gets the by filter T.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        IList<T> GetByFilterT(GetByFilterParameters parameters);



        /// <summary>
        /// Gets the by ID.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        T GetByIDT(object keyValues, GetByIDParameters parameters = null);


        /// <summary>
        /// Gets all the records. (view data) It shouldn't be used unless the view has a few records for sure
        /// </summary>
        /// <returns></returns>
        IList<V> GetAllV();


        /// <summary>
        /// Gets the by filter. (view data)
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        IList<V> GetByFilterV(GetByFilterParameters parameters);



        /// <summary>
        /// Gets the by ID. (view data)
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        V GetByIDV(object keyValues, GetByIDParameters parameters = null);

    }

}
