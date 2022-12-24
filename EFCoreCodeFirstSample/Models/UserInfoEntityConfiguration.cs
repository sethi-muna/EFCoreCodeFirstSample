using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Models
{
    public class UserInfoEntityConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> userBuilder)
        {
            userBuilder.HasData(new UserInfo
            {
                UserId = 1,
                UserName = "Ram",
                Email = "ram@mail.com",
                Password = "xyz",
                CreatedDate = DateTime.Now
            });
        }
    }
}
