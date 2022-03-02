using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineAuction.Domain.Entities.Base
{
    public abstract class Entity : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; protected set; }

        public Entity Clone()
        {
            return (Entity)this.MemberwiseClone();
        }
    }
}
