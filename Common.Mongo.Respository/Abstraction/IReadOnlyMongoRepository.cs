using Common.Mongo.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Common.Mongo.Respository.Abstraction
{
    /// <summary>
    /// The IReadOnlyMongoRepository exposes the readonly functionality of the BaseMongoRepository.
    /// </summary>
    public interface IReadOnlyMongoRepository
    {
        /// <summary>
        /// The connection string.
        /// </summary>
        string ConnectionString { get; set; }
        /// <summary>
        /// The database name.
        /// </summary>
        string DatabaseName { get; set; }

        #region Read

        /// <summary>
        /// Asynchronously returns one document given its id.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="id">The Id of the document you want to get.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        Task<TDocument> GetByIdAsync<TDocument>(Guid id, string partitionKey = null) where TDocument : IBaseModel;

        /// <summary>
        /// Returns one document given its id.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="id">The Id of the document you want to get.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        TDocument GetById<TDocument>(Guid id, string partitionKey = null) where TDocument : IBaseModel;

        /// <summary>
        /// Asynchronously returns one document given an expression filter if it is not Isdeleted.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        Task<TDocument> GetOneAsync<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey = null) where TDocument : IBaseModel;

        /// <summary>
        /// Asynchronously returns one document given an expression filter even though IsDeleted is set to true
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="filter"></param>
        /// <param name="partitionKey"></param>
        /// <returns></returns>
        Task<TDocument> GetOneAsyncWithDeleted<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey = null) where TDocument : IBaseModel;

        /// <summary>
        /// Returns one document given an expression filter if IsDeleted is false.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        TDocument GetOne<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey = null) where TDocument : IBaseModel;

        /// <summary>
        /// Returns one docuent given an expression filter even though IsDeleted is true
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <param name="filter"></param>
        /// <param name="partitionKey"></param>
        /// <returns></returns>
        TDocument GetOneWithDeleted<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey = null) where TDocument : IBaseModel;
        /// <summary>
        /// Returns a collection cursor.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        IFindFluent<TDocument, TDocument> GetCursor<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey = null) where TDocument : IBaseModel;

        /// <summary>
        /// Asynchronously returns true if any of the document of the collection matches the filter condition.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        Task<bool> AnyAsync<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey = null) where TDocument : IBaseModel;

        /// <summary>
        /// Returns true if any of the document of the collection matches the filter condition.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        bool Any<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey = null) where TDocument : IBaseModel;

        /// <summary>
        /// Asynchronously returns a list of the documents matching the filter condition excluding IsDeleted records.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        Task<List<TDocument>> GetAllAsync<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey = null) where TDocument : IBaseModel;

        /// <summary>
        /// Get all records with sorting
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <typeparam name="TNewProjection"></typeparam>
        /// <param name="filter"></param>
        /// <param name="projection"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        Task<List<TNewProjection>> GetAllWithOrderByAsync<TDocument, TNewProjection>(FilterDefinition<TDocument> filter,
            Expression<Func<TDocument, TNewProjection>> projection, int pageSize, int pageNumber,
            Expression<Func<TDocument, object>> sortBy) where TDocument : IBaseModel;

		/// <summary>
		/// Get all records with descending sorting
		/// </summary>
		/// <typeparam name="TDocument"></typeparam>
		/// <typeparam name="TNewProjection"></typeparam>
		/// <param name="filter"></param>
		/// <param name="projection"></param>
		/// <param name="pageSize"></param>
		/// <param name="pageNumber"></param>
		/// <param name="sortBy"></param>
		/// <returns></returns>
		Task<List<TNewProjection>> GetAllWithOrderByDescendingAsync<TDocument, TNewProjection>(FilterDefinition<TDocument> filter,
		   Expression<Func<TDocument, TNewProjection>> projection, int pageSize, int pageNumber,
		   Expression<Func<TDocument, object>> sortBy) where TDocument : IBaseModel;

		/// <summary>
		/// Asynchronously returns a list of the documents matching the filter condition if its not IsDeleted with paged list.
		/// </summary>
		/// <typeparam name="TDocument">The type representing a Document.</typeparam>
		/// <param name="filter">A LINQ expression filter.</param>
		/// <param name="partitionKey">An optional partition key.</param>
		Task<List<TNewProjection>> GetAllAsync<TDocument, TNewProjection>(FilterDefinition<TDocument> filter,
			Expression<Func<TDocument, TNewProjection>> projection, int pageSize, int pageNumber) where TDocument : IBaseModel;


		/// <summary>
		/// Returns a list of the documents matching the filter condition if its not IsDeleted with paged list.
		/// </summary>
		/// <typeparam name="TDocument">The type representing a Document.</typeparam>
		/// <param name="filter">A LINQ expression filter.</param>
		/// <param name="partitionKey">An optional partition key.</param>
		List<TNewProjection> GetAll<TDocument, TNewProjection>(FilterDefinition<TDocument> filter,
			Expression<Func<TDocument, TNewProjection>> projection, int pageSize, int pageNumber) where TDocument : IBaseModel;

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TDocument"></typeparam>
		/// <typeparam name="TNewProjection"></typeparam>
		/// <param name="filter"></param>
		/// <param name="projection"></param>
		/// <param name="partitionKey"></param>
		/// <returns></returns>
		Task<List<TNewProjection>> GetAllAndProjectAsync<TDocument, TNewProjection>
            (FilterDefinition<TDocument> filter, ProjectionDefinition<TDocument, TNewProjection> projection, string partitionKey = null) where TDocument : IBaseModel;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <typeparam name="TNewProjection"></typeparam>
        /// <param name="filter"></param>
        /// <param name="projection"></param>
        /// <param name="partitionKey"></param>
        /// <returns></returns>
        Task<List<TNewProjection>> GetAllAndProjectAsyncWithLinq<TDocument, TNewProjection>
            (Expression<Func<TDocument, bool>> filter, ProjectionDefinition<TDocument, TNewProjection> projection, string partitionKey = null) where TDocument : IBaseModel;
        /// <summary>
        /// returns all documents asynchronously 
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <returns></returns>
        Task<List<TDocument>> GetAllAsync<TDocument>() where TDocument : IBaseModel;
        /// <summary>
        /// Asynchronously returns a list of the documents matching the filter defination.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A filter defination.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        Task<List<TDocument>> FindAsync<TDocument>(FilterDefinition<TDocument> filter, string partitionKey = null) where TDocument : IBaseModel;

        /// <summary>
        /// find and project asynchronously list of documents
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <typeparam name="TNewProjection"></typeparam>
        /// <param name="filter"></param>
        /// <param name="projection"></param>
        /// <param name="partitionKey"></param>
        /// <returns></returns>
        Task<List<TNewProjection>> FindAndProjectAsync<TDocument, TNewProjection>
            (FilterDefinition<TDocument> filter, Expression<Func<TDocument, TNewProjection>> projection, string partitionKey = null) where TDocument : IBaseModel;

        /// <summary>
        /// find first record and project asynchronously list of documents
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <typeparam name="TNewProjection"></typeparam>
        /// <param name="filter"></param>
        /// <param name="projection"></param>
        /// <param name="partitionKey"></param>
        /// <returns></returns>
        Task<TNewProjection> GetOneAndProjectAsync<TDocument, TNewProjection>
            (FilterDefinition<TDocument> filter, Expression<Func<TDocument, TNewProjection>> projection, string partitionKey = null) where TDocument : IBaseModel;

        /// <summary>
        /// Asynchronously returns a list of the documents matching the filter condition including IsDeleted records.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        Task<List<TDocument>> GetAllAsyncWithDeleted<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey = null) where TDocument : IBaseModel;

        /// <summary>
        /// Returns a list of the documents matching the filter condition excluding IsDeleted records.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        List<TDocument> GetAll<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey = null) where TDocument : IBaseModel;

        /// <summary>
        /// Returns a list of the documents matching the filter defination.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A filter defination.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        List<TDocument> Find<TDocument>(FilterDefinition<TDocument> filter, string partitionKey = null) where TDocument : IBaseModel;

        /// <summary>
        /// find and project output
        /// </summary>
        /// <typeparam name="TDocument"></typeparam>
        /// <typeparam name="TNewProjection"></typeparam>
        /// <param name="filter"></param>
        /// <param name="projection"></param>
        /// <param name="partitionKey"></param>
        /// <returns></returns>
        List<TNewProjection> FindAndProject<TDocument, TNewProjection>
            (FilterDefinition<TDocument> filter, Expression<Func<TDocument, TNewProjection>> projection, string partitionKey = null) where TDocument : IBaseModel;

        /// <summary>
        /// Returns a list of the documents matching the filter condition including IsDeleted records.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        List<TDocument> GetAllWithIsDeleted<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey = null) where TDocument : IBaseModel;
        /// <summary>
        /// Asynchronously counts how many documents match the filter condition.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        Task<long> CountAsync<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey = null) where TDocument : IBaseModel;

        /// <summary>
        /// Counts how many documents match the filter condition.
        /// </summary>
        /// <typeparam name="TDocument">The type representing a Document.</typeparam>
        /// <param name="filter">A LINQ expression filter.</param>
        /// <param name="partitionKey">An optional partition key.</param>
        long Count<TDocument>(Expression<Func<TDocument, bool>> filter, string partitionKey = null) where TDocument : IBaseModel;

        #endregion
    }

}
