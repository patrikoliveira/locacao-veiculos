using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Domain.Services.Communication
{
    public class EntityResponse : BaseResponse
    {
        private EntityResponse(bool success, string message, IEntity entity) : base(success, message)
        {
            Entity = entity;
        }

        public IEntity Entity { get; set; }
        
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="entity">Created Entity.</param>
        /// <returns>Response.</returns>
        public EntityResponse(IEntity entity) : this(true, string.Empty, entity)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public EntityResponse(string message) : this(false, message, null)
        { }
        
    }
}