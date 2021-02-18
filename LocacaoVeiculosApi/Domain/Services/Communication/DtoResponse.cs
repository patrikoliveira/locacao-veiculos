namespace LocacaoVeiculosApi.Domain.Services.Communication
{
    public class DtoResponse<T> where T: class
    {
        private DtoResponse(bool success, string message, T entity)
        {
            Entity = entity;
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        
        public T Entity { get; set; }
        
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="entity">Created Entity.</param>
        /// <returns>Response.</returns>
        public DtoResponse(T entity) : this(true, string.Empty, entity)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public DtoResponse(string message) : this(false, message, null)
        { }
        
    }
}