namespace Authentication.Common.Entity
{
    public class BaseEntity
    {
        public virtual long Id { get; protected set; }
        public virtual StatusType Status { get; set; }

        public BaseEntity()
        {
            this.Status = StatusType.Available;
        }
    }
}
