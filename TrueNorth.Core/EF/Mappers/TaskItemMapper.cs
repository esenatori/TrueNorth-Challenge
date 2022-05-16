using Microsoft.EntityFrameworkCore;
using TrueNorth.Core.Tasks;
namespace TrueNorth.Core.EF.Mappers
{
    public class TaskItemMapper
    {
        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<TaskItem>()
                .HasKey(g => g.UUID);
             
        }
    }
}