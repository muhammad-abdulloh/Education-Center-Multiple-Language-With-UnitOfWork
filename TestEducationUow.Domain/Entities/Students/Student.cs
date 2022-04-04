using System;
using TestEducationCenterUoW.Domain.Commons;
using TestEducationCenterUoW.Domain.Enums;

namespace TestEducationCenterUoW.Domain.Entities.Students
{
    public class Student : IAuditable
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public Guid? GroupId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public ItemState State { get; set; }
        public string Image { get; set; }


        public void Update()
        {
            UpdatedAt = DateTime.Now;
            State = ItemState.Updated;
        }

        public void Create()
        {
            CreatedAt = DateTime.Now;
            State = ItemState.Created;
        }

        public void Delete()
        {
            State = ItemState.Deleted;
        }


    }
}
