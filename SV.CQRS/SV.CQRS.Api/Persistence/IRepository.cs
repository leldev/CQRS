using SV.CQRS.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SV.CQRS.Api.Persistence
{
    public interface IRepository
    {
        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <typeparam name="T">Document base.</typeparam>
        /// <param name="item">T item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<T> CreateItemAsync<T>(T item)
            where T : DocumentBase;

        /// <summary>
        /// Deletes permanently an item.
        /// </summary>
        /// <typeparam name="T">Document base.</typeparam>
        /// <param name="id">Document id.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task DeleteItemAsync<T>(string id)
            where T : DocumentBase;

        /// <summary>
        /// Returns a collection of dynamic items.
        /// </summary>
        /// <typeparam name="T">Document base.</typeparam>
        /// <param name="expression">Lambda expression.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<dynamic>> GetDynamicItemsAsync<T>(Expression<Func<T, bool>> expression)
            where T : DocumentBase;

        /// <summary>
        /// Returns an item.
        /// </summary>
        /// <typeparam name="T">Document base.</typeparam>
        /// <param name="id">Document Id.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<T> GetItemAsync<T>(string id)
            where T : DocumentBase;

        /// <summary>
        /// Returns a collection with all items.
        /// </summary>
        /// <typeparam name="T">Document base.</typeparam>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<T>> GetItemsAsync<T>()
            where T : DocumentBase;

        /// <summary>
        /// Returns a collection with all items.
        /// </summary>
        /// <typeparam name="T">Document base.</typeparam>
        /// <param name="expression">Lambda expression.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<T>> GetItemsAsync<T>(Expression<Func<T, bool>> expression)
            where T : DocumentBase;

        /// <summary>
        /// Updates an item.
        /// </summary>
        /// <typeparam name="T">Document base.</typeparam>
        /// <param name="item">Item to update.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<T> UpdateItemAsync<T>(T item)
            where T : DocumentBase;
    }
}