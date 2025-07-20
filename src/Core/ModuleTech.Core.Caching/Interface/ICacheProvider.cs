namespace ModuleTech.Core.Caching.Interface;


/// <summary>
///     Base Cache Provider
/// </summary>
public interface ICacheProvider
{
    string? Get(string key);

    /// <summary>
    ///     GetAs the value of the associated the given key
    /// </summary>
    /// <param name="key">Identifier of the <see cref="TData" /> to retrieve from cache</param>
    /// <typeparam name="TData">
    ///     <see cref="TData" />
    /// </typeparam>
    /// <returns>Return <see cref="TData" /> otherwise return null</returns>
    TData? GetAs<TData>(string key) where TData : class, new();

    Task<string?> GetAsync(string key, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Async overload of the <see cref="GetAs{TData}" />
    /// </summary>
    /// <param name="key">
    ///     <inheritdoc cref="GetAs{TData}" />
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TData">
    ///     <inheritdoc cref="GetAs{TData}" />
    /// </typeparam>
    /// <returns>
    ///     <inheritdoc cref="GetAs{TData}" />
    /// </returns>
    Task<TData?> GetAsAsync<TData>(string key, CancellationToken cancellationToken = default) where TData : class, new();

    bool Set(string key, string data, TimeSpan expireTime);

    /// <summary>
    ///     Insert the <see cref="TData" /> to the cache
    /// </summary>
    /// <param name="key">Identifier of the <see cref="TData" /></param>
    /// <param name="data"><see cref="TData" /> to be added to the cache</param>
    /// <param name="expireTime">Expire time of the <see cref="key" /></param>
    /// <typeparam name="TData">
    ///     <see cref="TData" />
    /// </typeparam>
    /// <returns>true if the <see cref="TData" /> was set, false otherwise.</returns>
    bool SetAs<TData>(string key, TData data, TimeSpan expireTime);

    Task<bool> SetAsync(string key, string data, TimeSpan expireTime,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Async overload of the <see cref="SetAs{TData}" />
    /// </summary>
    /// <param name="key">
    ///     <inheritdoc cref="SetAs{TData}" />
    /// </param>
    /// <param name="data">
    ///     <inheritdoc cref="SetAs{TData}" />
    /// </param>
    /// <param name="expireTime">
    ///     <inheritdoc cref="SetAs{TData}" />
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TData">
    ///     <inheritdoc cref="SetAs{TData}" />
    /// </typeparam>
    /// <returns>
    ///     <inheritdoc cref="SetAs{TData}" />
    /// </returns>
    Task<bool> SetAsAsync<TData>(string key, TData data, TimeSpan expireTime,
        CancellationToken cancellationToken = default);


    /// <summary>
    ///     Remove specificed key' data from cache
    /// </summary>
    /// <param name="key">Identifier of the to delete from cache</param>
    /// <returns>true if the key was deleted, false otherwise.</returns>
    bool Remove(string key);

    /// <summary>
    ///     Async overload of the <see cref="Remove" />
    /// </summary>
    /// <param name="key">
    ///     <see cref="Remove" />
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    ///     <inheritdoc cref="Remove" />
    /// </returns>
    Task<bool> RemoveAsync(string key, CancellationToken cancellationToken = default);


    /// <summary>
    ///     Remove all Datas in the cache
    /// </summary>
    void Clear();

    /// <summary>
    ///     Async overload of the <see cref="Clear" />
    /// </summary>
    /// <returns></returns>
    Task ClearAsync(CancellationToken cancellationToken = default);
}